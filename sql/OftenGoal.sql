--delete from TestOutput


--TestNew --OftenGoal
	select * from TestOutput where FLAG=77888844
	select COUNT(*) as aa, a30,a29 from TestOutput where FLAG=77888844 group by A30,a29 order by aa desc	
	select * from TestOutput where FLAG=77888855 order by ROUND desc
	select COUNT(*) as aa, a30,a29 from TestOutput where FLAG=77888855 group by A30,a29 order by aa desc


select * from TestOutput where FLAG=778888

select COUNT(*) as aa, a12 from TestOutput where FLAG=7788884 group by A12 order by aa desc
select COUNT(*) as aa, a13 from TestOutput where FLAG=7788884 group by A13 order by aa desc
select COUNT(*) as aa, a14 from TestOutput where FLAG=7788884 group by A14 order by aa desc

select * from testoutput where flag = 7788884 and A12 = '3|20|24|26' order by round, a12
select COUNT(*) as aa, a12 from TestOutput where FLAG=7788884 group by A12 order by aa desc

select * from TestOutput where FLAG=7788885 and a0 = 2000 order by ROUND desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=7788885 group by A12 order by aa
select COUNT(*) as aa, a13 from TestOutput where FLAG=7788885 group by A13 order by aa 
select COUNT(*) as aa, a14 from TestOutput where FLAG=7788885 group by A14 order by aa 
select COUNT(*) as aa, a15 from TestOutput where FLAG=7788885 group by A15 order by aa 

select * from testoutput where flag = 7788885 and a12 ='10|18|19|25|27'--4 10 18 19 25 27 

select * from TestOutput where FLAG=7788886 and A24 <> '' order by ROUND desc
select * from TestOutput where FLAG=7788886 and A23 <> '' order by ROUND desc
select COUNT(*) as aa, a16 from TestOutput where FLAG=7788886 group by A16 order by aa desc
select COUNT(*) as aa, a17 from TestOutput where FLAG=7788886 group by A17 order by aa desc
select COUNT(*) as aa, a18 from TestOutput where FLAG=7788886 group by A18 order by aa desc
select COUNT(*) as aa, a19 from TestOutput where FLAG=7788886 group by A19 order by aa desc
select COUNT(*) as aa, a20 from TestOutput where FLAG=7788886 group by A20 order by aa desc
select COUNT(*) as aa, a21 from TestOutput where FLAG=7788886 group by A21 order by aa desc
select COUNT(*) as aa, a22 from TestOutput where FLAG=7788886 group by A22 order by aa desc
select COUNT(*) as aa, a22 /5 from TestOutput where FLAG=7788886 group by A22 /5 order by aa desc

select * from TestOutput where FLAG=7788886 and A22>15 and A22 < 35


/*MyNumber*/select 5 as num, '|' as a, COUNT(*) as aa, a12 as hh from TestOutput where FLAG=7788885 group by A12 
union 
select 5 as num, '_' as a,COUNT(*) as aa, a13 as hh from TestOutput where FLAG=7788885 group by A13 
union
select 5 as num, '/' as a,COUNT(*) as aa, a15 as hh from TestOutput where FLAG=7788885 group by A15
union
select 6 as num, '|' as a, COUNT(*) as aa, a12 as hh from TestOutput where FLAG=7788886 group by A12 
union 
--select 6 as num, '_' as a,COUNT(*) as aa, a13 as hh from TestOutput where FLAG=7788886 group by A13 
select 6 as num, '_' as a,COUNT(*) as aa, a14 as hh from TestOutput where FLAG=778888555 group by A14 
union
select 6 as num, '/' as a,COUNT(*) as aa, a15 as hh from TestOutput where FLAG=7788886 group by A15 order by num,a 


select COUNT(*) as aa, a14 from TestOutput where FLAG=7788886 group by A14 order by aa 

select * from TestOutput where FLAG=77888855 order by ROUND desc

select * from TestOutput where FLAG=77888855 and 
(abs(convert(float,a5) - A21)<=5 
or abs(convert(float,a5) - A23)<=5
or abs(convert(float,a5) - A25)<= 5
or abs(convert(float,a5) - A27)<= 5
or abs(convert(float,a5) - A29)<= 5)

select CAST(cast(a29 as decimal(9,0))/10 as decimal(9,0)),cast(a29 as decimal(9,0)),convert(float,a29),a29 from TestOutput where FLAG=77888855
select COUNT(*) as aa, CAST(cast(a29 as decimal(9,0))/10 as decimal(9,0)) from TestOutput where FLAG=77888855 group by CAST(cast(a29 as decimal(9,0))/10 as decimal(9,0)) order by aa
select COUNT(*) as aa, CAST(cast(a28 as decimal(9,0))/10 as decimal(9,0)) from TestOutput where FLAG=77888855 group by CAST(cast(a28 as decimal(9,0))/10 as decimal(9,0)) order by aa

select * from TestOutput where FLAG=778888555 and A13 not like '%0%'
select COUNT(*) as aa, a19 from TestOutput where FLAG=77888855 group by A19 order by aa
select COUNT(*) as aa, a18 from TestOutput where FLAG=77888855 group by A18 order by aa
select COUNT(*) as aa, a17 from TestOutput where FLAG=77888855 group by A17 order by aa
select COUNT(*) as aa, a16 from TestOutput where FLAG=778888555 group by A16 order by aa
select * from TestOutput where A16 = '1_2_3_5_6_10'
select COUNT(*) as aa, a13 from TestOutput where FLAG=77888855 group by A13 order by aa 

select COUNT(*) as aa, a14 from TestOutput where FLAG=778888555 group by A14 order by aa 

select COUNT(*) as aa, a15 from TestOutput where FLAG=77888855 group by A15 order by aa 

select COUNT(*) as aa, a3 from TestOutput where FLAG=77888855 group by A3 order by aa 
select COUNT(*) as aa, a4 from TestOutput where FLAG=77888855 group by A4 order by aa 
select COUNT(*) as aa, a3,a4 from TestOutput where FLAG=77888855 group by a3,A4 order by aa 
select COUNT(*) as aa, a3 + a4,a4 from TestOutput where FLAG=77888855 group by a3 +a4,A4 order by a4 
select COUNT(*) as aa, a3 + a4,a4 from TestOutput where FLAG=77888855 group by a3 +a4,A4 order by a3+a4 

select COUNT(*) as aa, a6 from TestOutput where FLAG=77888855 group by A6 order by aa 
select COUNT(*) as aa, a6,a2/10 from TestOutput where FLAG=77888855 group by A6,A2/10 order by aa  
select a3,a4 from TestOutput where FLAG=77888855 and  a3>=A4 and A4 <> 0

select COUNT(*) as aa, a2 from TestOutput where FLAG=77888855 group by A2 order by aa desc
select * from TestOutput where FLAG=77888855 and A2 >=20and A2 <=  30
select * from TestOutput where FLAG=77888855 and A2 >=25 and A2 <=  33

