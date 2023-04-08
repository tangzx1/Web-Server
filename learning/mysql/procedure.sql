-- delimiter是mysql分隔符，在mysql客户端中分隔符默认是分号（；）。如果一次输入的语句较多，并且语句中间有分号，这时需要新指定一个特殊的分隔符。
delimiter $$
CREATE PROCEDURE hello_procrdure()
BEGIN
		SELECT * from t_user;


end $$ 

-- 调用
CALL hello_procrdure() 


delimiter $$
CREATE PROCEDURE sp_var01()
BEGIN
		DECLARE user_name VARCHAR(32) DEFAULT 'rose';
		set user_name='t';
		select user_name;

end $$ 

-- 删除函数
DROP PROCEDURE sp_var01;

CALL sp_var01();



delimiter //
CREATE PROCEDURE sp_var01()
BEGIN
-- 局部变量
		DECLARE user_name VARCHAR(32) DEFAULT 'rose';
		set user_name='t';
		select user_name;

end //

delimiter //
CREATE PROCEDURE sp_var02()
BEGIN
-- 设置用户变量
		set @uname='t';

end //

CALL sp_var02();

SELECT @uname


delimiter //
CREATE PROCEDURE sp_var03()
BEGIN
-- 用into设置用户变量
		SELECT user_name INTO @user_name from t_user;

end //

CALL sp_var03();

SELECT @user_name



delimiter //
CREATE PROCEDURE sp_param01(in nickname VARCHAR(32))
BEGIN
-- 用into设置用户变量
		set @user_name=nickname;

end //

CALL sp_param01('test');

SELECT @user_name


-- 出参
delimiter //
CREATE PROCEDURE sp_param02(in user_name VARCHAR(32),out user_age INT)
BEGIN
		SELECT age into user_age from t_user tu where tu.user_name=user_name ;

end //

CALL sp_param02('Jack',@dept_name);

SELECT @dept_name;


-- 出参入参inout
delimiter //
CREATE PROCEDURE sp_param03(INOUT user_name VARCHAR(32))
BEGIN
		DECLARE user_age int DEFAULT 1;
		SELECT age into user_age from t_user tu where tu.user_name=user_name ;
		set user_name= CONCAT(user_name,'-',user_age);
end //

set @user_name='Jack';
CALL sp_param03(@user_name);
SELECT @user_name;


-- if判断
delimiter //
CREATE PROCEDURE sp_if()
BEGIN
		DECLARE result VARCHAR(32);
		DECLARE years int;
		SELECT TIMESTAMPDIFF(year,tu.record_date,now()) INTO years from t_user tu where tu.user_name='Jack';
		if years < 10 then
			 set result='10';
		ELSEIF years<50 then
			 set result='50';
		ELSE
			set result='over';
		END if;
		SELECT result;
end //

CALL sp_if();


-- case
delimiter //
CREATE PROCEDURE sp_case1()
BEGIN
		DECLARE result VARCHAR(32);
		DECLARE years int;
		SELECT TIMESTAMPDIFF(year,tu.record_date,now()) INTO years from t_user tu where tu.user_name='Jack';
		CASE
			WHEN years<10 THEN
				set result='10';
			WHEN years<50 then
				set result='50';
			ELSE
			set result='over';
		END CASE;

		SELECT result;
end // 

CALL sp_case1();


-- case
delimiter //
CREATE PROCEDURE sp_case2()
BEGIN
		DECLARE result VARCHAR(32);
		DECLARE years int DEFAULT 10;
		CASE years
			WHEN 10 THEN
				set result='10';
			WHEN 50 then
				set result='50';
			ELSE
			set result='over';
		END CASE;

		SELECT result;
end // 

CALL sp_case2();




-- loop
delimiter //
CREATE PROCEDURE sp_loop()
BEGIN
		DECLARE c_index int DEFAULT 1;
		num_loop:loop
			SELECT c_index;
			if c_index>=10 THEN
				LEAVE num_loop;
			end if;
			
			SET c_index=c_index+1;
		END loop num_loop;
end // 

CALL sp_loop();



-- CURSOR
delimiter //
CREATE PROCEDURE show_emp(in emp_name VARCHAR(32))
BEGIN
		DECLARE e_id int DEFAULT 1;
		DECLARE e_no int DEFAULT 1;
		DECLARE e_name VARCHAR(32);
		DECLARE e_sal DECIMAL(10,2);
		
		DECLARE emp_cursor CURSOR FOR
			SELECT * from t_employee
			where t_employee.`name`!=emp_name;
		
		OPEN emp_cursor;
		
		FETCH emp_cursor INTO e_id,e_no,e_name,e_sal;
		SELECT e_id,e_no,e_name,e_sal;
		
		FETCH emp_cursor INTO e_id,e_no,e_name,e_sal;
		SELECT e_id,e_no,e_name,e_sal;
		
		CLOSE emp_cursor;
end // 

CALL show_emp('aa');



 -- CURSOR HANDLER
delimiter //
CREATE PROCEDURE show_emp_handler(in emp_name VARCHAR(32))
BEGIN
 		DECLARE e_id int DEFAULT 1;
 		DECLARE e_no int DEFAULT 1;
 		DECLARE e_name VARCHAR(32);
		DECLARE e_sal  DECIMAL(10,2);
		
 		DECLARE lp_flag int DEFAULT 1;
 		
		DECLARE emp_cursor CURSOR FOR
 			SELECT * from t_employee
 			where t_employee.`name`!=emp_name;
 		
 		DECLARE CONTINUE HANDLER FOR 1329 SET lp_flag=0;
		
 		OPEN emp_cursor;
 		
		emp_loop:loop
			FETCH emp_cursor into e_id,e_no,e_name,e_sal;
			
			if lp_flag=1 THEN
				SELECT e_id,e_no,e_name,e_sal;
 			ELSE
 				LEAVE emp_loop;
		END if;
			
		END loop emp_loop;
		CLOSE emp_cursor;
 end // 

 CALL show_emp_handler('aa');






-- demo
delimiter //
CREATE PROCEDURE change_salary(in emp_name VARCHAR(32))
BEGIN
 		DECLARE e_id int DEFAULT 1;
 		DECLARE e_no int DEFAULT 1;
 		DECLARE e_name VARCHAR(32);
		DECLARE e_sal  DECIMAL(10,2);
		
 		DECLARE lp_flag int DEFAULT 1;
 		
		DECLARE emp_cursor CURSOR FOR
 			SELECT * from t_employee
 			where t_employee.`name`!=emp_name;
 		
 		DECLARE CONTINUE HANDLER FOR NOT found SET lp_flag=0;
		
 		OPEN emp_cursor;
 		
		emp_loop:loop
			FETCH emp_cursor into e_id,e_no,e_name,e_sal;
			
			if lp_flag=1 THEN
				UPDATE t_employee te set te.salary=te.salary+100 where te.id=e_id;
 			ELSE
 				LEAVE emp_loop;
		END if;
			
		END loop emp_loop;
		CLOSE emp_cursor;
 end // 

 CALL change_salary('jack');



-- create TABLE 
delimiter //
CREATE PROCEDURE create_table()
BEGIN
 		DECLARE next_year int DEFAULT 1;
 		DECLARE next_month int DEFAULT 1;
		DECLARE next_month_last_day int DEFAULT 1;
 		DECLARE next_month_str VARCHAR(32);
		DECLARE next_month_day_str VARCHAR(32);
		
-- 	每天的表名
		DECLARE table_name_str VARCHAR(32);
		
		DECLARE t_index int DEFAULT 1;
		
-- 	下一个月的年份
		set next_year=YEAR(DATE_ADD(NOW(),INTERVAL 1 MONTH));
-- 	下个月的月份
		set next_month=MONTH(DATE_ADD(NOW(),INTERVAL 1 MONTH));
-- 	下个月的最后一天
		SET next_month_last_day=DAYOFMONTH(LAST_DAY(DATE_ADD(NOW(),INTERVAL 1 MONTH)));
 		
		if (next_month<10) THEN
				set next_month_str=CONCAT('0',next_month);
			else
				set next_month_str=CONCAT('',next_month);
			end if;
		
		
		WHILE t_index<=next_month_last_day DO
			if (t_index<10) THEN
				set next_month_day_str=CONCAT('0',t_index);
			else
				set next_month_day_str=CONCAT('',t_index);
			end if;
			
			set table_name_str = CONCAT(next_year,'_',next_month_str,'_',next_month_day_str);
			
			set @create_table_sql=CONCAT('create table t_comp_',table_name_str,' (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `employee_no` int UNSIGNED NULL DEFAULT NULL,
  `employee_name` varchar(50) ,
  `salary` decimal(10, 2) UNSIGNED NOT NULL DEFAULT 1.00,
  PRIMARY KEY (`id`) USING BTREE
)');
	-- from后面不能使用局部变量
-- 	MySQL 官方将 prepare、execute、deallocate 统称为 PREPARE STATEMENT。翻译也就习惯的称其为预处理语句。
			PREPARE create_table_stmt FROM @create_table_sql;
			EXECUTE create_table_stmt;
			DEALLOCATE PREPARE create_table_stmt;
			
			set t_index=t_index+1;
		END WHILE;

 end // 

 CALL create_table();
 
 
 
 








