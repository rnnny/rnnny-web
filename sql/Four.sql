--delete from TestOutput
--delete from TestOutput where flag = 444444

select * from testoutput where FLAG = 44444400


select COUNT(*) as aa, A12 from TestOutput where FLAG =44444400  group by A12 order by aa desc
select COUNT(*) as aa, A12 from TestOutput where FLAG =44444400 and A11=6  group by A12 order by aa desc
select COUNT(*) as aa, A13,round from TestOutput where FLAG =44444400 and A11=6  group by A13,round order by round desc
select COUNT(*) as aa, A12 from TestOutput where FLAG =44444400 and A11=5  group by A12 order by aa desc
select COUNT(*) as aa, A13,round from TestOutput where FLAG =44444400 and A11=5  group by A13,round order by round desc

select * from TestOutput where FLAG =444444 order by ROUND desc
select * from TestOutput where FLAG =444444 and a0= 4 order by ROUND desc

select COUNT(*) as aa, A13 from TestOutput where FLAG =444444 and a0= 5  group by A13 order by aa
select COUNT(*) as aa, A9 from TestOutput where FLAG =444444 and a0= 5  group by A9 order by aa
select COUNT(*) as aa, A9 from TestOutput where FLAG =444444 and a0= 5  group by A9 order by a9
select COUNT(*) as aa, a10,A11 from TestOutput where FLAG =444444 and a0= 5  group by a10,A11 order by aa desc
select COUNT(*) as aa, A13 from TestOutput where FLAG =444444 and a0= 4  group by A13 order by aa desc
select COUNT(*) as aa, A9 from TestOutput where FLAG =444444 and a0= 4  group by A9 order by aa
select COUNT(*) as aa, A9 from TestOutput where FLAG =444444 and a0= 4  group by A9 order by a9
select COUNT(*) as aa, a10,A11 from TestOutput where FLAG =444444 and a0= 4  group by a10,A11 order by aa desc
select a12,a13 from TestOutput where A13 in(
select a13 from
(select COUNT(*) as aa,a13 from TestOutput where FLAG =444444 and a0= 4  group by A13 ) bb
where aa>3) order by a13 desc

select * from TestOutput where FLAG =44444433 order by ROUND desc
select COUNT(*) as aa, A2 from TestOutput where FLAG =44444433 group by A2 order by aa desc
select COUNT(*) as aa, A2 from TestOutput where FLAG =44444433 and A26='true'  group by A2 order by aa desc
select COUNT(*) as aa, a1,A2 from TestOutput where FLAG =44444433 and A1 <> -1  group by a1,A2 order by aa desc
select COUNT(*) as aa, a1,A2 from TestOutput where FLAG =44444433 and A26='true' and A1 <> -1  group by a1,A2 order by aa desc
select  a1,A2,a1+a2 from TestOutput where FLAG =44444433 and A26='true' and A1 <> -1  order by A1+a2 
select COUNT(*) as aa, a1,A2 from TestOutput where FLAG =44444433 and A1 <> -1  group by a1,A2 order by aa desc

select * from TestOutput where FLAG =44444488 order by ROUND desc
select * from TestOutput where FLAG =44444488 and a30 = 'true' order by ROUND desc
select * from TestOutput where FLAG =44444488 and round = '2017074'order by ROUND desc
select * from TestOutput where FLAG =44444488 and A2 = 1 order by ROUND desc
select COUNT(*) as aa, A2 from TestOutput where FLAG =44444488  group by A2 order by aa desc
select COUNT(*) as aa, A2 from TestOutput where FLAG =44444488  group by A2 order by a2
select COUNT(*) as aa, A2 from TestOutput where FLAG =44444488 and a30 = 'true'  group by A2 order by aa desc
select COUNT(*) as aa, A2 from TestOutput where FLAG =44444488 and a30 = 'true'  group by A2 order by a2 

select * from TestOutput where FLAG =44444488 and a30 = 'true' and A2 >= 1000

select COUNT(*) as aa, A2/10 from TestOutput where FLAG =44444488 and a30 = 'true'  group by A2/10 order by aa desc
