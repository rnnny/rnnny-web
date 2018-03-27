--delete from TestOutput
--delete from TestOutput where flag = 777777
--delete from TestOutput where flag = 77777711

select a0, count(*) as aa from TestOutput where FLAG = 77777711 group by A0 order by aa 
select a1, count(*) as aa from TestOutput where FLAG = 77777711 group by A1 order by aa 
select a1,a0, count(*) as aa from TestOutput where FLAG = 77777711 group by A1,a0 order by a1 

select a11,a10, count(*) as aa from TestOutput where FLAG = 77777711 group by A11,a10 order by a11 
select * from TestOutput where FLAG = 77777711 and A1 = 1 and A0 = 0

select * from TestOutput where FLAG = 77777733 order by ROUND desc
select * from TestOutput where FLAG = 77777733 and A10 >= 8 and a11 >= 8 and A12 >=8 and A13 >=8 and A14 >= 8 and A15 >=8
select * from TestOutput where FLAG = 77777733 and A10 <= 10 and a11 <= 10 and A12 <=10 and A13 <=10 and A14 <= 10 and A15 <=10

select * from TestOutput where FLAG = 77777722
select a1,a0, count(*) as aa from TestOutput where FLAG = 77777722 group by A1,a0 order by a1 
select a3, count(*) as aa from TestOutput where FLAG = 77777722 group by A3 order by a3
select a5, count(*) as aa from TestOutput where FLAG = 77777722 group by A5 order by a5
select a7, count(*) as aa from TestOutput where FLAG = 77777722 group by A7 order by a7
select a9, count(*) as aa from TestOutput where FLAG = 77777722 group by A9 order by a9
select a11, count(*) as aa from TestOutput where FLAG = 77777722 group by A11 order by a11 

select a3,a2, count(*) as aa from TestOutput where FLAG = 77777722 group by A3,a2 order by a3
select a5,a4, count(*) as aa from TestOutput where FLAG = 77777722 group by A5,a4 order by a5
select a7,a6, count(*) as aa from TestOutput where FLAG = 77777722 group by A7,a6 order by a7
select a9,a8, count(*) as aa from TestOutput where FLAG = 77777722 group by A9,a8 order by a9
select a11,a10, count(*) as aa from TestOutput where FLAG = 77777722 group by A11,a10 order by a11 


select * from TestOutput where FLAG = 77777744 order by A14 desc
select * from TestOutput where FLAG = 77777744 and A12 like'%a%'order by A14 desc
select a12, count(*) as aa from TestOutput where FLAG = 77777744 group by A12 order by aa 
select a15, count(*) as aa from TestOutput where FLAG = 77777744 group by A15 order by aa 

select a13, count(*) as aa from TestOutput where FLAG = 77777744 group by A13 order by aa 
select a1, count(*) as aa from TestOutput where FLAG = 777777 group by A1 order by aa 
select a15, count(*) as aa from TestOutput where FLAG = 777777 group by A15 order by aa 
select a16, count(*) as aa from TestOutput where FLAG = 777777 group by A16 order by aa 
select a17, count(*) as aa from TestOutput where FLAG = 777777 group by A17 order by aa 

select cast(a15 as decimal(9,1)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a15 as decimal(9,1)) order by aa 
select cast(a16 as decimal(9,1)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a16 as decimal(9,1)) order by aa 
select cast(a17 as decimal(9,1)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a17 as decimal(9,1)) order by aa 


select cast(a15 as decimal(9,0)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a15 as decimal(9,0)) order by aa 
select cast(a16 as decimal(9,0)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a16 as decimal(9,0)) order by aa 
select cast(a17 as decimal(9,0)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a17 as decimal(9,0)) order by aa 

select cast(a16 as decimal(9,0)) - cast(a17 as decimal(9,0)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a16 as decimal(9,0)) - cast(a17 as decimal(9,0)) order by aa 
select cast(a15 as decimal(9,0)) - cast(a16 as decimal(9,0)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a15 as decimal(9,0)) - cast(a16 as decimal(9,0)) order by aa 


select cast(a16 as decimal(9,1)) - cast(a17 as decimal(9,1)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a16 as decimal(9,1)) - cast(a17 as decimal(9,1)) order by aa 
select cast(a15 as decimal(9,1)) - cast(a16 as decimal(9,1)), count(*) as aa from TestOutput where FLAG = 777777 group by cast(a15 as decimal(9,1)) - cast(a16 as decimal(9,1)) order by aa 
select cast(a15 as decimal(9,2)) - cast(a16 as decimal(9,2)), cast(a15 as decimal(9,2))as a15, cast(a16 as decimal(9,2)) as a16 from TestOutput


select a24, count(*) as aa from TestOutput where FLAG = 777777 group by A24 order by aa 
select a25, count(*) as aa from TestOutput where FLAG = 777777 group by A25 order by aa 

select COUNT(*) from TestOutput where FLAG = 777777 and A24 in 
(000001, 100000,122222,222221 ,000002,000022,000222,002222,022222,222222,222220,222200,222000,220000,200000,000000)

select COUNT(*) from TestOutput where FLAG = 777777 and A24 not like '%1%' 

select COUNT(*) from TestOutput where FLAG = 777777 and A15 not like '%2%'  and A15 not like '%3%'  and A16 not like '%2%'  and A16 not like '%3%'

select COUNT(*) from TestOutput where FLAG = 777777 and( A15  like '%2%'  or A15 like '%3%' ) and (A16 like '%2%'  or A16 like '%3%')
select a1, count(*) as aa from TestOutput where FLAG = 777777 group by a1 order by aa 


select * from TestOutput where FLAG = 777777 order by a14 desc
select * from TestOutput where FLAG = 777777 and A1>= 4 and A1 <= 9 order by a14 desc

/*<5*/select * from TestOutput where FLAG = 777777 AND A24 not like '%7%' AND A24 not like '%5%'AND A24 not like '%6%' order by a14 desc
select * from TestOutput where FLAG = 777777 AND A24 not like '%3%' AND A24 not like '%0%'AND A24 not like '%6%' order by a14 desc

select * from TestOutput where FLAG = 777777 AND A14 not like '%9%' AND A14 not like '%7%' AND A14 not like '%8%'AND A14 not like '%6%' order by a14 desc

 