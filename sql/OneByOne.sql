--delete from TestOutput
select * from TestOutput where FLAG=111222 and A2 = 0 order by a13 desc
/**/select COUNT(*) as aa, a0, a1 from TestOutput where FLAG = 111222 group by A0, a1 order by aa desc

select * from TestOutput where FLAG = 9999 order by A2 
select COUNT(*),A1,SUM(A2) as ok from TestOutput where FLAG = 9999 group by A1 order by ok desc 
select COUNT(*),A0,SUM(A2) as ok from TestOutput where FLAG = 9999 group by A0 order by ok desc 
select COUNT(*) as ok,A12 from TestOutput group by A12 order by ok desc
select COUNT(*)as ok,a8,a9 from TestOutput group by a8,a9 order by ok desc
select sum(convert(float,A12)) as ok,flag from TestOutput group by FLAG order by ok

select COUNT(*),flag from TestOutput group by FLAG
select COUNT(*)as ok,flag from TestOutput where A8=6 group by FLAG order by ok desc
select COUNT(*)as ok,flag from TestOutput where A8=5 or A8=4 group by FLAG order by ok desc

select COUNT(*) as ok, A0 ,A2,A4,a6,flag  from TestOutput group by FLAG, A0 ,A2,A4,a6 order by ok desc

select COUNT(*) as ok, A0 ,A2,A4,a6,A8,a9,flag  from TestOutput group by flag, A0 ,A2,A4,a6,A8,a9 order by ok desc

select avg(convert(float,a8)/convert(float,a9)) as a8a9, AVG(convert(float,a8)) as a8, 
AVG(convert(float,a9)) as a9, flag from TestOutput where A9 <> 0 group by flag order by a8 desc
select avg(convert(float,a8)/convert(float,a9)) as a8a9, AVG(convert(float,a8)) as a8, 
AVG(convert(float,a9)) as a9, flag from TestOutput where A9 <> 0 group by flag order by a8a9 desc

select convert(float,a0)/convert(float,a1) as aa,  a0, 
 a1, flag from TestOutput where A1 <> 0 and FLAG = 73 order by aa
 select convert(float,a4)/convert(float,a5) as aa,  a4, 
 a5, flag from TestOutput where A5 <> 0 and FLAG = 73 order by aa
 select convert(float,a6)/convert(float,a7) as aa,  a6, 
 a7, flag from TestOutput where A7 <> 0 and FLAG = 73 order by aa
 select convert(float,a10)/convert(float,a11) as aa,  a10, 
 a11, flag from TestOutput where A11 <> 0 and FLAG = 73 order by aa
 select convert(float,a8)/convert(float,a9) as aa,  a8, 
 a9, flag from TestOutput where A9 <> 0 and FLAG = 73 order by aa
 
/*4*/select COUNT(*)as ok,a8 from TestOutput where FLAG = 73 group by a8 order by a8
/*8*/select COUNT(*)as ok,a6 from TestOutput where FLAG = 73 group by a6 order by a6
/*6*/select COUNT(*)as ok,a4 from TestOutput where FLAG = 73 group by a4 order by a4
/*5*/select COUNT(*)as ok,a0 from TestOutput where FLAG = 73 group by a0 order by a0
/*9*/select COUNT(*)as ok,a10 from TestOutput where FLAG = 73 group by a10 order by a10
/*4-5-6-7-8-9*/select COUNT(*)as ok from TestOutput where FLAG = 73 and (a8 = 2 or A8 = 3 or A8 = 4 or A8 = 5 or A8 = 6) and (a0 = 0 or A0 = 1 or A0 = 2 or A0 = 3)and (A4 = 0 or A4 = 1 or A4 = 2 or A4 = 3) and (A6 = 2 or A6 = 1 or A6 = 0)and(A10 = 0 or A10 = 1 or A10 = 2 or A10 = 3 or A10 = 4)
select COUNT(*)as ok from TestOutput where FLAG = 73 
and convert(float,a0)/convert(float,a1)< 0.25 and A1 <> 0 
and convert(float,a4)/convert(float,a5)< 0.25 and A5 <> 0
and convert(float,a6)/convert(float,a7)< 0.25 and A7 <> 0
and convert(float,a10)/convert(float,a11)< 0.25 and A11 <> 0
select * from TestOutput where FLAG = 119 order by FLAG

select var(a8) as a88 , var(a9) as a99, flag from TestOutput group by flag order by a88
select var(a8) as a88 , var(a9) as a99, flag from TestOutput group by flag order by a99

select avg(
(case when a0 != 0 then a1 else 0 end) 
+ (case when a2 != 0 then a3 else 0  end) 
+ (case when a4 != 0 then a5 else 0  end) 
+ (case when a6 != 0 then a7 else 0  end)
+ (case when a10 != 0 then a11 else 0  end))
, flag  from TestOutput group by flag order by flag
select 
(case when a0 != 0 then a1 else 0 end) 
, (case when a2 != 0 then a3 else 0  end) 
, (case when a4 != 0 then a5 else 0  end) 
, (case when a6 != 0 then a7 else 0  end)
, (case when a10 != 0 then a11 else 0  end)
, flag,id  from TestOutput order by id

select COUNT(a0) as a00, flag from TestOutput where A0=0 group by FLAG order by a00 desc  

select COUNT(a7) as a77, flag from TestOutput where A7=0 group by FLAG order by a77 desc

select avg(convert(float,a0)/convert(float,a1)) as a0a1, AVG(convert(float,a0)) as a0, 
AVG(convert(float,a1)) as a1,flag from TestOutput where A1 <> 0 group by flag order by a0
select avg(convert(float,a0)/convert(float,a1)) as a0a1, AVG(convert(float,a0)) as a0, 
AVG(convert(float,a1)) as a1,flag from TestOutput where A1 <> 0 group by flag order by a0a1

select avg(convert(float,a7)/convert(float,a8)) as a7a8, AVG(convert(float,a7)) as a7, 
AVG(convert(float,a8)) as a8,flag from TestOutput where A8 <> 0 group by flag order by a8
select avg(convert(float,a7)/convert(float,a8)) as a7a8, AVG(convert(float,a7)) as a7, 
AVG(convert(float,a8)) as a8,flag from TestOutput where A8 <> 0 group by flag order by a7a8
