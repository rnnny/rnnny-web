--delete from TestOutput
--delete from TestOutput where flag = 555555
select COUNT(*) from TestOutput
select * from TestOutput where FLAG=555555 and A0 = 0 order by FLAG, a0

select * from TestOutput where FLAG=55555503 order  by ROUND desc
select COUNT(*) as aa, A10 - a11 from TestOutput where FLAG=55555503  group by A10-a11 order by aa desc
select COUNT(*) as aa, A10 - a11 from TestOutput where FLAG=55555504  group by A10-a11 order by aa desc
select COUNT(*) as aa, A10 - a11 from TestOutput where FLAG=55555505  group by A10-a11 order by aa desc
select COUNT(*) as aa, A10 - a11 from TestOutput where FLAG=55555506  group by A10-a11 order by aa desc

select COUNT(*) as aa, a12 from TestOutput where A0 <> 0 group by A12 order by aa desc
select COUNT(*) as aa, a13 from TestOutput where A0 <> 0 group by A13 order by aa desc
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a13 having count(*) <=40) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a13 having count(*) >40) as bb
select COUNT(*) as aa, a14 from TestOutput where A0 <> 0 group by A14 order by aa desc
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a14 having count(*) <=5) as bb
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a14 having count(*) >5) as bb
select COUNT(*) as aa, a15 from TestOutput where A0 <> 0 group by A15 order by aa desc
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a15 having count(*) =1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a15 having count(*) <>1) as bb
select COUNT(*) as aa, a16 from TestOutput where A0 <> 0 group by A16 order by aa desc
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a16 having count(*) =1) as bb
/**/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where A0 <> 0 group by a16 having count(*) <>1) as bb

--select a1, A16, a15 from TestOutput where A0 =0 and  A15='03$02$00$01$03$'
/*0*/select a1, A16, a15 from TestOutput where FLAG=555555 and A0 =0 
and A15 in (select a15 from TestOutput where FLAG=555555 and A0 <> 0 group by a15)
/*0*/select a1, A16, a15 from TestOutput where FLAG=555555 and A0 =0 
and A16 in (select a16 from TestOutput where FLAG=555555 and A0 <> 0 group by a16)
/*0*/select a1, A15, a14 from TestOutput where FLAG=555555 and A0 =0 
and A14 in (select bb.a14 from (select COUNT(*) as aa, a14 from TestOutput where FLAG=555555 and A0 <> 0 group by a14 having count(*) >5) as bb)
/*0*/select a1, A13, a15 from TestOutput where FLAG=555555 and A0 =0 
and A13 in (select bb.a13 from (select COUNT(*) as aa, a13 from TestOutput where FLAG=555555 and A0 <> 0 group by a13 having count(*) >40) as bb)


/*a13NEW*/select a1, A15, aa.a13, bb.a13 from TestOutput aa left join (select a13 from TestOutput where FLAG=555555 and A0 <> 0 group by a13) bb on aa.A13 = bb.a13  
where aa.a0 = 0 and bb.A13 is null and FLAG = 555555
order by a1

select * from TestOutput where A15 = '00$00$01$01$03$'
select * from TestOutput where A13 = '05$07$08$'

select a1, A13, aa.a15, bb.a15 from TestOutput aa left join (select a15 from TestOutput where A0 <> 0 group by a15) bb on aa.A15 = bb.a15  
where aa.a0 = 0 and bb.A15 is null
and A13 in (select a13 from TestOutput where A0 <> 0 group by a13) 
order by a1

select a1, A15, aa.a13, bb.a13 from TestOutput aa left join (select a13 from TestOutput where A0 <> 0 group by a13) bb on aa.A13 = bb.a13  
where aa.a0 = 0 and (bb.A13 is null
or A15 in (select a15 from TestOutput where A0 <> 0 group by a15) )
order by a1


select * from TestOutput where FLAG = 5555551
select * from TestOutput where convert(float,A29) <=5 and FLAG = 5555551
select COUNT(*) as aa , a0 / 10, a1 /10 from TestOutput where FLAG = 5555551 group by A0 /10, A1/10 order by aa

select COUNT(*) as aa , a0 / 10 from TestOutput where FLAG = 5555551 group by A0 /10 order by aa

select COUNT(*) as aa , a1 /10 from TestOutput where FLAG = 5555551 group by A1/10 order by aa


select COUNT(*) as aa , a12 from TestOutput where FLAG = 5555551 group by A12 order by aa


select * from TestOutput where A12 like '%-3-3-2-1%'

select * from TestOutput where A12 like '%-1-3-3-2%'


select * from TestOutput where FLAG = 5555552

select COUNT(*) as aa , a3 from TestOutput where FLAG = 5555552 group by A3 order by aa


select COUNT(*) as aa , a3,a4 from TestOutput where FLAG = 5555552 group by A3,a4 order by a3

