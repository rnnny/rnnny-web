--delete from TestOutput
select sum(a2) from TestOutput where flag = 7777
select sum(a2) from TestOutput where flag = 6666
select * from TestOutput where FLAG = 5555 order by A2 desc 
select sum(a2) as aa, a1 from TestOutput where flag = 5555 group by a1 order by aa desc
select sum(a2) as aa, a1 from TestOutput where flag = 6666 group by a1 order by aa desc
select sum(a2) as aa, a1 from TestOutput where flag = 7777 group by a1 order by aa desc

select COUNT(*) as aa, a12 from TestOutput where FLAG=56 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=66 group by a12 order by aa desc

select *  from TestOutput where FLAG=16 and a12 = '120102010303'
select COUNT(*) as aa from TestOutput where FLAG=16
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=16 group by a12 order by aa 
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=15 group by a12 order by aa 
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=14 group by a12 order by aa desc
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=13 group by a12 order by aa 
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=14 group by a12 having count(*) <=2) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=14 group by a12 having count(*) >2) as bb


select COUNT(*) as aa, a12 from TestOutput where FLAG=26 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=25 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=24 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=23 group by a12 order by aa desc

select COUNT(*) as aa, a12 from TestOutput where FLAG=36 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=35 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=34 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=33 group by a12 order by aa desc

/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=46 group by a12 order by aa
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=45 group by a12 order by aa 
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=44 group by a12 order by aa
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=43 group by a12 order by aa 
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=44 group by a12 having count(*) <=2) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=44 group by a12 having count(*) >2) as bb

select *  from TestOutput where FLAG=45 and A12 = '0304020105'
 
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=96 group by a12 order by aa
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=95 group by a12 order by aa 
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=94 group by a12 order by aa
/*11*/select COUNT(*) as aa, a12 from TestOutput where FLAG=93 group by a12 order by aa 
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=94 group by a12 having count(*) <=2) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=94 group by a12 having count(*) >2) as bb

select COUNT(*) as aa from TestOutput where FLAG=94
select COUNT(*) as aa from TestOutput where FLAG=44
select COUNT(*) as aa from TestOutput where FLAG=14
select COUNT(*) as aa, a12 from TestOutput where FLAG=66 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=65 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=64 group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=63 group by a12 order by aa desc

/*3*/select COUNT(*) as aa, a12 from TestOutput where FLAG=76 group by a12 order by aa desc
/*10*/select COUNT(*) as aa, a12 from TestOutput where FLAG=86 group by a12 order by aa desc

/**/select sum(bb.aa), sum(bb.aa) * 0.9  from (select COUNT(*) as aa from TestOutput where FLAG=76 group by a12) as bb

/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=76 group by a12 having count(*) >=100) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG=86 group by a12 having count(*) >=100) as bb


select COUNT(*) as aa from TestOutput where FLAG=36 and a12 not like '%2%' 
select COUNT(*) as aa from TestOutput where FLAG=35 and a12 not like '%2%' 
select COUNT(*) as aa from TestOutput where FLAG=34 and a12 not like '%2%' 
select COUNT(*) as aa from TestOutput where FLAG=33 and a12 not like '%2%' 

select COUNT(*) as aa from TestOutput where FLAG=66 and a12 not like '%2%' 
select COUNT(*) as aa from TestOutput where FLAG=65 and a12 not like '%2%' 
select COUNT(*) as aa from TestOutput where FLAG=64 and a12 not like '%2%' 
select COUNT(*) as aa from TestOutput where FLAG=63 and a12 not like '%2%' 

select COUNT(*) as aa, a12 from TestOutput where FLAG=36 and a12 not like '%1%' group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=35 and a12 not like '%1%' group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=34 and a12 not like '%1%' group by a12 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=33 and a12 not like '%1%' group by a12 order by aa desc

select *  from TestOutput where FLAG = 888888
select A0, COUNT(*) as aa  from TestOutput where FLAG = 888888 group by A0 order by aa
select A0, COUNT(*) as aa  from TestOutput where FLAG = 888888 group by A0 order by a0
select A0 / 10, COUNT(*) as aa  from TestOutput where FLAG = 888888 group by A0 /10 order by aa

/*UPUP*/select COUNT(*) as aa  from TestOutput where FLAG = 888888  and A0 >= 11 and A0 <= 45