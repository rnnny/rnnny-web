--delete from TestOutput
--delete from TestOutput where flag <> 666666

select * from TestOutput
select * from TestOutput order by ROUND desc, flag

select * from TestOutput where FLAG = 3 order by ROUND desc 
select * from TestOutput where FLAG = 3  and a11 >= 0 order by ROUND desc 
select a12,COUNT(*) aa from TestOutput where FLAG = 3 group by a12 order by aa desc 
select COUNT(*) from TestOutput
select COUNT(*),flag from TestOutput group by flag

select a1, flag, COUNT(*) as aa from TestOutput group by FLAG, a1 order by flag, aa
select a4, flag, COUNT(*) as aa from TestOutput group by FLAG, a4 order by flag, aa
select a10, COUNT(*) as aa from TestOutput where FLAG = 2 group by  a10 order by  aa
select * from TestOutput where FLAG = 2 and A10 <= 20

/*flag=2 10-29*/select a5 / 10, flag, COUNT(*) as aa from TestOutput group by FLAG, A5 /10 order by flag, aa

select a5 % 9, flag, COUNT(*) as aa from TestOutput group by FLAG, A5 % 9 order by flag, aa

select a5 / flag, COUNT(*) as aa from TestOutput group by  A5 / flag order by  aa

select COUNT(*)as aa, flag from TestOutput where FLAG <= 50 group by flag
/*1-1171*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a12 having count(*) <=1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a12 having count(*) <=1) as bb
/*1*/select COUNT(*)as aa, A12  from TestOutput where FLAG = 3 group by a12 order by aa desc
/*1*/select COUNT(*)as aa, A12  from TestOutput where FLAG = 4 group by a12 order by aa desc
/**/select * from TestOutput where FLAG = 3 and A12 like '%|09|01%'
/**/select * from TestOutput where FLAG = 4 and A12 like '%|01|04|07%'
/*2--1341*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a13 having count(*) <=1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=5 group by a13 having count(*) <=1) as bb
/*2*/select COUNT(*)as aa, A13  from TestOutput where FLAG = 5 group by a13 order by aa desc
/*2*/select COUNT(*)as aa, A13  from TestOutput where FLAG = 4 group by a13 order by aa desc
/**/select * from TestOutput where FLAG = 5 and A13 like '%/11/10/11/12%'
/**/select * from TestOutput where FLAG = 4 and A13 like '%/07/11/10%'
/*12--1495*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a14 having count(*) <>2) as bb
/*12--1461*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a14 having count(*) <=1) as bb
/*12*/select COUNT(*)as aa, A14  from TestOutput where FLAG = 3 group by a14 order by aa desc
/*12*/select COUNT(*)as aa, A14  from TestOutput where FLAG = 4 group by a14 order by aa desc
/*12*/select COUNT(*)as aa, A14  from TestOutput where FLAG = 5 group by a14 order by aa desc
/**/select * from TestOutput where FLAG = 5 and A14 like '%-06-09-06-04%'
/**/select * from TestOutput where FLAG = 4 and A14 like '%-01-09-09%'
/**/select * from TestOutput where FLAG = 3 and A14 like '%-01-09%'
/*13--1266*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a15 having count(*) <=1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a15 having count(*) <=1) as bb
/*13*/select COUNT(*)as aa, A15  from TestOutput where FLAG = 3 group by a15 order by aa desc
/*13*/select COUNT(*)as aa, A15  from TestOutput where FLAG = 4 group by a15 order by aa desc
/**/select * from TestOutput where FLAG = 4 and A15 like '%-01-09-09%'
/**/select * from TestOutput where FLAG = 3 and A15 like '%-01-09%'
/*14--1472*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a16 having count(*) <=1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a16 having count(*) <=1) as bb
/*14*/select COUNT(*)as aa, A16  from TestOutput where FLAG = 3 group by a16 order by aa desc
/*14*/select COUNT(*)as aa, A16  from TestOutput where FLAG = 4 group by a16 order by aa desc
/**/select * from TestOutput where FLAG = 4 and A16 like '%-13-14-17%'
/**/select * from TestOutput where FLAG = 3 and A16 like '%-10-13%'
/*15--1441*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a17 having count(*) <=1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a17 having count(*) <=1) as bb
/*15*/select COUNT(*)as aa, A17  from TestOutput where FLAG = 3 group by a17 order by aa desc
/*15*/select COUNT(*)as aa, A17  from TestOutput where FLAG = 4 group by a17 order by aa desc
/**/select * from TestOutput where FLAG = 4 and A17 like '%-26-20-23%'
/**/select * from TestOutput where FLAG = 3 and A17 like '%-11-26%'
/*16--1310*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a18 having count(*) <=1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a18 having count(*) <=1) as bb
/*16*/select COUNT(*)as aa, A18  from TestOutput where FLAG = 3 group by a18 order by aa desc
/*16*/select COUNT(*)as aa, A18  from TestOutput where FLAG = 4 group by a18 order by aa desc
/**/select * from TestOutput where FLAG = 4 and A18 like '%-27-26-24%'
/**/select * from TestOutput where FLAG = 3 and A18 like '%-14-27%'
/*17--1517*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a19 having count(*) <>2) as bb
/*17--1541*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a19 having count(*) <>2) as bb
/*17*/select COUNT(*)as aa, A19  from TestOutput where FLAG = 3 group by a19 order by aa desc
/*17*/select COUNT(*)as aa, A19  from TestOutput where FLAG = 4 group by a19 order by aa desc
/*17*/select COUNT(*)as aa, A19  from TestOutput where FLAG = 5 group by a19 order by aa desc
/**/select * from TestOutput where FLAG = 5 and A19 like '%-33-27-31-31%'
/**/select * from TestOutput where FLAG = 4 and A19 like '%-22-33-27%'
select COUNT(*)as aa, A20  from TestOutput where FLAG = 3 group by a20 order by aa desc
select COUNT(*)as aa, A20  from TestOutput where FLAG = 4 group by a20 order by aa desc
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=3 group by a20 having count(*) >4) as bb
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=4 group by a20 having count(*) =1) as bb
select COUNT(*)as aa, A23 /10  from TestOutput where FLAG = 4 group by a23 /10 order by a23 /10 desc
select COUNT(*)as aa, A23  from TestOutput where FLAG = 2 group by a23 order by a23 desc
select COUNT(*)as aa, A24  from TestOutput where FLAG = 2 group by a24 order by aa desc
select COUNT(*)as aa, A24  from TestOutput where FLAG = 4 group by a24 order by aa desc
select * from TestOutput where FLAG = 2 order by A2
select COUNT(*) from TestOutput where FLAG = 2 and (A24 = '大大' or A24 = '中中' or A24 = '小小' )
update TestOutput set A25 = 0 where FLAG = 2 and (A24 = '大大' or A24 = '中中' or A24 = '小小' )

select * from TestOutput where FLAG = 4 and A20 like '%&11&03&04%'
select * from TestOutput where FLAG = 3 and A20 like '%&11&03%' order by a20

select COUNT(*)as aa, A21  from TestOutput where FLAG = 10 group by a21 order by aa desc
/*18-25*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=9 group by a22 having count(*) =1) as bb
/*18-25*/select COUNT(*)as aa, A22  from TestOutput where FLAG = 9 group by a22 order by aa desc
/*18-25*/select * from TestOutput where FLAG < 8 and A2 = 1

select COUNT(*)as aa, a2,a22 from TestOutput where FLAG = 8 or FLAG = 9 group by a2,a22 order by aa 

select count(a0) as aa,a0,flag from TestOutput group by flag, a0 order by aa desc
select count(a1) as aa,a1,flag from TestOutput group by flag, a1 order by aa desc

select var(a1) as aa,flag from TestOutput group by flag order by aa
select var(a0) as aa,flag from TestOutput group by flag order by aa

/**/select * from TestOutput where FLAG <= 50 and A2 =1 order by FLAG  
select * from TestOutput where FLAG <= 2 order by a2
select COUNT(*) as aa,a4,flag from TestOutput where FLAG <= 50 group by flag,a4 order by flag,A4
select COUNT(*) as aa,a4 from TestOutput where FLAG <= 50 group by a4 order by aa desc
select COUNT(*) as aa from TestOutput where FLAG <= 50 and A4 >= 7 and A4 <= 10

/**/select * from TestOutput where FLAG <= 50 and A2 =1 order by FLAG
select * from TestOutput where FLAG <= 2 order by a2
select COUNT(*) as aa,a6,flag from TestOutput where FLAG <= 50 group by flag,a6 order by flag,A6
select COUNT(*) as aa,a6 from TestOutput where FLAG <= 50 group by a6 order by aa desc
select COUNT(*) as aa,a8 from TestOutput where FLAG = 2 group by a8 order by aa desc

/**/select COUNT(*) from TestOutput where FLAG <= 50 and A2 = 1 and A0  < 0
/**/select COUNT(*) from TestOutput where FLAG <= 50 and A2 = 1 and A0  > 0
select COUNT(*)as aa, flag from TestOutput where FLAG <= 50 and A0 * A3 <= 0 and A0 <> 0 and A3 <> 0 group by flag order by aa desc
select COUNT(*)as aa, a2 from TestOutput where FLAG <= 50 and A0 * A3 < 0 and A0 <> 0 and A3 <> 0 group by a2 order by  aa,a2 desc
select COUNT(*)as aa, a2 from TestOutput where FLAG <= 50 and ( A0 = 0 or A3 = 0 )group by a2 order by  a2 desc
select COUNT(*)as aa, a2 from TestOutput where FLAG <= 50 and A0 * A3 > 0 and A0 <> 0 and A3 <> 0 group by a2 order by  aa,a2 desc

select count(*) as aa,flag from TestOutput where A1 <= 11 group by flag order by aa desc

select count(a1) as aa,a1,a2 from TestOutput group by a2, a1 order by aa desc

select count(*) as aa,flag from TestOutput where A1 <= 2  group by flag order by aa desc

select COUNT(*)as aa, a0 from TestOutput where FLAG = '7777' group by a0 order by aa desc
select COUNT(*)as aa from TestOutput where FLAG = '7777' and a0 < 15 order by aa desc

select COUNT(*)as aa from TestOutput where FLAG = '3333'
select * from TestOutput where FLAG = '3333'


select COUNT(*)as aa from TestOutput where FLAG = '4444'
select * from TestOutput where FLAG = '4444'
select avg(a2) as aaa,var(a2) as aa,var(a0) as bb,var(a1) as cc,flag from TestOutput where FLAG = '4444' group by flag

select COUNT(*)as aa from TestOutput where FLAG = '5555'
select * from TestOutput where FLAG = '5555'
select avg(a2) as aaa,var(a2) as aa,var(a0) as bb,var(a1) as cc,flag from TestOutput where FLAG = '5555' group by flag
