--delete from TestOutput
--delete from TestOutput where flag = 999999

select * from TestOutput where FLAG= 000000 order by ROUND desc
select * from TestOutput where FLAG= 000000 and A2 = 5 order by ROUND desc
select * from TestOutput where FLAG =999999 and a26= 'BCCCCC'order by ROUND desc
select COUNT(*) as aa, A1 from TestOutput where FLAG =000000 group by A1 order by aa desc
select COUNT(*) as aa, A2 from TestOutput where FLAG =000000 group by A2 order by aa desc

select * from TestOutput where FLAG = 99999966 order by A1,round desc
select * from TestOutput where FLAG = 99999966 and A1=99 order by A0,round desc
select COUNT(*) as aa, A0,a1 from TestOutput where FLAG = 99999966 group by A0,a1 order by aa 

select * from TestOutput where FLAG = 99999902 order by ROUND desc,a7

select COUNT(*) as aa, round from TestOutput where FLAG = 99999902 
and A7 in (1,22,26,14,20,8,17,32,7,18,3,30,27)
group by round order by aa desc,round desc
select COUNT(*) as aa, A0 from TestOutput where FLAG = 99999902 group by a0 order by a0 desc
select COUNT(*) as aa, A0/10 from TestOutput where FLAG = 99999902 group by a0/10 order by a0/10 desc
select COUNT(*) as aa, A7 from TestOutput where FLAG =99999902 group by A7 order by aa desc
select COUNT(*) as aa, A7 from TestOutput where FLAG =99999902 and A0=90 group by A7 order by aa desc
select COUNT(*) as aa, A7 from TestOutput where FLAG =99999902 and A0/10=8 group by A7 order by aa desc
select COUNT(*) as aa, A7 from TestOutput where FLAG =99999902 and a0/10=7 group by A7 order by aa desc

select COUNT(*) as aa, A7 from TestOutput where FLAG =99999902 and ROUND in 
(select round from TestOutput where FLAG=999999 --and A0/10 <= 7
and A12 not like '%33%' and A12 not like '%32%' and A12 not like '%31%'
and A12 not like '%30%' and A12 not like '%29%' and A12 not like '%28%'
and A12 not like '%27%' and A12 not like '%26%' and A12 not like '%25%'
and A12 not like '%24%' and A12 not like '%23%' --and A12 not like '%22%'
)
group by A7 order by aa desc

select * from TestOutput where FLAG=999999 --and A0/10 <= 7
and A12 not like '%33%' and A12 not like '%24%' and A12 not like '%15%'
and A12 not like '%28%' and A12 not like '%11%' and A12 not like '%31%'
and A12 not like '%23%' and A12 not like '%21%' and A12 not like '%09%'
and A12 not like '%29%' and A12 not like '%25%' --and A12 not like '%23%'

select * from TestOutput where FLAG=999999 --and A0/10 <= 7
and A12 not like '%33%' and A12 not like '%32%' and A12 not like '%31%'
and A12 not like '%30%' and A12 not like '%29%' and A12 not like '%28%'
and A12 not like '%27%' and A12 not like '%26%' and A12 not like '%25%'
and A12 not like '%24%' and A12 not like '%23%' --and A12 not like '%22%'

select * from TestOutput where FLAG=999999 --and A0/10 <= 7
and A12 not like '%12%' and A12 not like '%13%' and A12 not like '%14%'
and A12 not like '%15%' and A12 not like '%16%' and A12 not like '%17%'
and A12 not like '%18%' and A12 not like '%19%' and A12 not like '%20%'
and A12 not like '%21%' and A12 not like '%22%' --and A12 not like '%22%'

select * from TestOutput where FLAG=999999 --and A0/10 <= 7
and A12 not like '%1%' and A12 not like '%2%' and A12 not like '%3%'
and A12 not like '%4%' and A12 not like '%5%' and A12 not like '%6%'
and A12 not like '%7%' and A12 not like '%8%' and A12 not like '%9%'
and A12 not like '%10%' and A12 not like '%11%' --and A12 not like '%22%'


select * from TestOutput where FLAG =99999900 order by ROUND desc
select * from TestOutput where FLAG=99999900 and len(a17)=14
select * from TestOutput where FLAG=99999900 order by a18
select COUNT(*) as aa, A12 from TestOutput where FLAG =99999900 group by A12 order by aa desc
select COUNT(*) as aa, A12 from TestOutput where FLAG =99999900 group by A12 order by a12 desc
select COUNT(*) as aa, LEFT(ROUND,4) from TestOutput where FLAG =99999900 and A12 >= 17 group by LEFT(ROUND,4) order by LEFT(ROUND,4) desc
select COUNT(*) as aa, A13,a14,a12 from TestOutput where FLAG =99999900 group by A13,a14,a12 order by aa desc
select COUNT(*) as aa, A13 from TestOutput where FLAG =99999900 group by A13 order by aa desc
select COUNT(*) as aa, a14 from TestOutput where FLAG =99999900 group by a14 order by aa desc
select * from TestOutput where FLAG =99999900 
and A26 not like '%00%'and A26 not like '%11%'and A26 not like '%22%' 
and A26 not like '%33%'and A26 not like '%44%'and A26 not like '%55%'
and A26 not like '%66%'and A26 not like '%77%'and A26 not like '%88%'and A26 not like '%99%'
order by ROUND desc
select * from TestOutput where FLAG =99999900 
and (A26 like '%000%'or A26 like '%1111%'or A26 like '%2222%' 
or A26 like '%3333%'or A26 like '%444%'or A26 like '%555%'
or A26 like '%666%'or A26 like '%777%'or A26 like '%888%'or A26 like '%999%')
order by ROUND desc
select * from TestOutput where FLAG =99999900 
and (A26 like '%00%'or A26 like '%11%'or A26 like '%22%' 
or A26 like '%33%'or A26 like '%44%'or A26 like '%55%'
or A26 like '%66%'or A26 like '%77%'or A26 like '%88%'or A26 like '%99%')
order by ROUND desc
select * from TestOutput where FLAG =99999900 
and (A28 like '%000%'or A28 like '%111%'or A28 like '%222%')
order by ROUND desc
select * from TestOutput where FLAG =99999900 
and (A28 like '%0000%'or A28 like '%1111%'or A28 like '%2222%')
order by ROUND desc
select * from TestOutput where FLAG =99999900 and A28 like '%0000%' order by ROUND desc
select COUNT(*) as aa, left(ROUND,4) from TestOutput where FLAG =99999900 and A28 like '%0000%' group by left(ROUND,4) order by left(ROUND,4) desc
/*相对较多*/select * from TestOutput where FLAG =99999900 and A28 like '%1111%' order by ROUND desc
/*2017年only3次*/select COUNT(*) as aa, left(ROUND,4) from TestOutput where FLAG =99999900 and A28 like '%1111%' group by left(ROUND,4) order by left(ROUND,4) desc
select * from TestOutput where FLAG =99999900 and A28 like '%2222%' order by ROUND desc
select COUNT(*) as aa, left(ROUND,4) from TestOutput where FLAG =99999900 and A28 like '%2222%' group by left(ROUND,4) order by left(ROUND,4) desc
/*十年磨一剑*/select * from TestOutput where FLAG =99999900 
and (A28 like '%0000%'or A28 like '%1111%'or A28 like '%2222%')
--and A28 not like '%3%'
and A27>='17' and A27<='35'
and A19>=41 and A19 <=159
and A30 not like '%33%' and A30 not like '%24%' and A30 not like '%15%'
and A30 not like '%28%' and A30 not like '%11%' and A30 not like '%31%'
and A30 not like '%23%' and A30 not like '%21%' and A30 not like '%09%'
and A30 not like '%29%' and A30 not like '%25%' --and A12 not like '%23%'
and ROUND in(
select ROUND from TestOutput where FLAG=999999
and A28 in ('b2b2c3', 'a2b2c3','a2c5', 'b2c5','c7') 
and (
A27 like '5%' or A23 like '4%' 
or A23 like '6%'
)
and A26 = 'BBBBBB'
and A10=0 and A11<=10
and A9>=24 and A9<=42
and A7>=7 and A7<=40
and (A3 = 2 or A3 = 3 or A3 = 4) --16
and (A4 = 2 or A4 = 3 or A4 = 4)--22
and (A5 = 2 or A5 = 3 or A5 = 4)--28
)
order by ROUND desc
select * from TestOutput where FLAG =99999900 
and (A28 like '%00000%'or A28 like '%11111%'or A28 like '%22222%')
order by ROUND desc
select * from TestOutput where FLAG =99999900 and A20 >4 and A21 > 4and A22> 4and A23>4 and A24>4 and A25> 4 order by ROUND desc
select * from TestOutput where FLAG =99999900 and A20 <=4 and A21 <=4and A22<=4and A23<=4 and A24<=4 and A25<=4 order by ROUND desc
select * from TestOutput where FLAG =99999900 and A27 >=20 and A27<30 order by ROUND desc
select * from TestOutput where FLAG=99999900 and A28 like '%00%'and A28 like '%11%' order by a28
select * from TestOutput where FLAG=99999900 and A28 like '%1111%'
select * from TestOutput where FLAG=99999900 and A28 not like '%3%'
select * from TestOutput where FLAG=99999900 and A6<=6
select DISTINCT * from TestOutput where A19=110 and FLAG=99999900 order by ROUND desc
select COUNT(*) as aa, A6 from TestOutput where FLAG =99999900 group by A6 order by a6 desc
select COUNT(*) as aa, A18 from TestOutput where FLAG =99999900 group by A18 order by aa desc
select COUNT(*) as aa, A18 from TestOutput where FLAG =99999900 group by A18 order by a18 desc
select COUNT(*) as aa, A27 from TestOutput where FLAG =99999900 group by A27 order by aa desc
select * from TestOutput where FLAG=99999900 and A27>='17' and A27<='35'
select COUNT(*) as aa, A28 from TestOutput where FLAG =99999900 group by A28 order by aa desc
select COUNT(*) as aa, A29 from TestOutput where FLAG =99999900 group by A29 order by aa desc
select COUNT(*) as aa, A29,a27 from TestOutput where FLAG =99999900 group by A29,a27 order by aa desc
select COUNT(*) as aa, A29,a27 /10from TestOutput where FLAG =99999900 group by A29,a27 /10order by aa desc
select COUNT(*) as aa, a26 from TestOutput where FLAG =99999900 group by A26 order by aa desc
select COUNT(*) as aa, a20 from TestOutput where FLAG =99999900 group by a20 order by aa desc
select COUNT(*) as aa, a22 from TestOutput where FLAG =99999900 group by a22 order by aa desc
select COUNT(*) as aa, a20,a22 from TestOutput where FLAG =99999900 group by A20,a22 order by a20 desc
select COUNT(*) as aa, a23 from TestOutput where FLAG =99999900 group by A23 order by aa desc
select COUNT(*) as aa, a24 from TestOutput where FLAG =99999900 group by A24 order by aa desc
select COUNT(*) as aa, a25 from TestOutput where FLAG =99999900 group by A25 order by aa desc
select * from TestOutput where flag=999999 and round in (select round from testoutput where FLAG=99999900 and A20='9.3')
select * from testoutput where FLAG=99999900 and  A20='9.3' order by ROUND desc
select COUNT(*) as aa, a26 from TestOutput where FLAG =99999900 
and A26 not like '%00%'and A26 not like '%11%'and A26 not like '%22%' 
and A26 not like '%33%'and A26 not like '%44%'and A26 not like '%55%'
and A26 not like '%66%'and A26 not like '%77%'and A26 not like '%88%'and A26 not like '%99%'
group by A26 order by aa desc

select * from TestOutput where FLAG =999999 order by ROUND desc
select COUNT(*) as aa, A0/10 from TestOutput where FLAG =999999 and left(ROUND,4)='2017' group by A0/10 order by aa desc

select COUNT(*) as aa, A0/10 as bb,'one' from (select top 50 * from TestOutput where FLAG=999999 order by round desc) aaa where FLAG =999999 group by A0/10 
union
select COUNT(*) as aa, A0/10 as bb,'two' from 
(select top 50 * from TestOutput where FLAG=999999 and ID not in (select top 50 id from TestOutput where FLAG=999999 order by round desc) order by round desc) aaa 
where FLAG =999999 group by A0/10 order by bb desc

select top 10 * from TestOutput where FLAG =999999 and A0 /10 = 7 order by ROUND desc
select * from TestOutput where FLAG =999999 and a6 <= 17
and A0 >=90 and A0 < 110
order by a6

select id,a7 from TestOutput where A7 = 48 and ID <> 2111 order by ID desc

select * from TestOutput where FLAG=999999 and A26='BBBBBB' order by A7

select * from TestOutput where FLAG=999999 
and (A26 ='BBBBBB' or A26 = 'ABBBBB' or A26 = 'BBBBBC')
and (A0 >=90 and A0 <= 110)
and (A3 >= 2 and A3 <= 4)
and (A4 >= 2 and A4 <= 4)
and (A5 >= 2 and A5 <= 4)
and (A6 >= 21 and A6 <= 30)
--and (A7 >= 11 and A7 <= 45)
and (a7 >= 11 and A7<= 30)
and (A8 >= 5 and A8 <= 11)
and (A9 >= 30 and A9 <= 49)
--and (A15='4' or A17 ='4' or A19 = '4')                      

select COUNT(*) as aa, a3,a4,a5,a6/10,a7/10,a8,a26 from TestOutput where FLAG =999999 group by a3,a4,a5,a6/10,a7/10,a8,A26 order by aa desc

select * from TestOutput where FLAG = 999999 and A28 like'%a3%'

select * from TestOutput where FLAG =999999 and A26 not like'%C%' order by ROUND desc
/*cccccc---ccccccb*/select COUNT(*) as aa, a26 from TestOutput where FLAG =999999 group by A26 order by aa desc

/**/select round,a0 as sum,a1 as repeat,a2 as near,a3 as repeatNear,a4 as prime, a5 as two,A8 as primetwonearrepeat,a6 as rightLeft, a7 as upup,A9 as sum30,A26,a27,a28 from TestOutput where FLAG =999999 order by ROUND desc

/*a1-repeat-4*/select COUNT(*) as aa, a1 from TestOutput where FLAG =999999 group by A1 order by aa desc

select COUNT(*) as aa, a1,A2,A4,a5 from TestOutput where FLAG =999999 group by A1,A2,A4,a5 order by aa desc
select * from TestOutput where A1 = 2 and A2 = 1 and A4 = 2 and A5 = 3 and FLAG = 999999 order by ROUND desc
select DISTINCT * from TestOutput where A0=110 and FLAG=999999 order by ROUND desc
select COUNT(*) as aa, a0/10 from TestOutput where FLAG =999999 group by A0/10 order by a0/10 desc
select COUNT(*) as aa, LEFT(ROUND,4) from TestOutput where FLAG =999999 and A0/10 = 13 group by LEFT(ROUND,4) order by LEFT(ROUND,4) desc
select COUNT(*) as aa, LEFT(ROUND,4) from TestOutput where FLAG =999999 and A0/10 = 6 group by LEFT(ROUND,4) order by LEFT(ROUND,4) desc

select COUNT(*) as aa, a0 from TestOutput where FLAG =999999 group by A0 order by aa desc
select * from TestOutput where FLAG=999999 and A0 >=70 and A0 <=130
select COUNT(*) as aa, a1 from TestOutput where FLAG =999999 group by A1 order by aa desc
select COUNT(*) as aa, a3 from TestOutput where FLAG =999999 group by A3 order by aa desc
select * from TestOutput where FLAG = 999999 and A3=6
select * from TestOutput where FLAG = 999999 and A1=4
select COUNT(*) as aa, a6 from TestOutput where FLAG =999999 group by A6 order by aa desc
select COUNT(*) as aa, a28 from TestOutput where FLAG =999999 group by A28 order by aa desc
select * from TestOutput where FLAG=999999 and len(A29)=11 and A29 not like '%9%'  and A29 not like '%8%'and A29 not like '%7%' and A29 not like '%6%'  and A29 not like '%5%' and A29 not like '%4%'

select * from TestOutput where FLAG = 999999 and A27 like '%6_%' order by round desc

/*prime==0质数为0*/select COUNT(*) as aa, a4 from TestOutput where FLAG =999999 group by A4 order by a4 desc
select * from TestOutput where FLAG = 999999 and A5=6 and A8 <=11 order by round desc
select * from TestOutput where FLAG = 999999 and A5=0 and A8 >=5 order by round desc
/*two==6 or two==0*/select COUNT(*) as aa, a5 from TestOutput where FLAG =999999 group by A5 order by a5 desc
select COUNT(*) as aa, a4,a5 from TestOutput where FLAG =999999 group by a4,A5 order by a4,a5 desc
select COUNT(*) as aa, a6 from TestOutput where FLAG =999999 group by A6 order by a6 desc
select * from TestOutput where A7 <= 6 and FLAG = 999999 order by round desc
select A7,A29,round from TestOutput where A7 <= 10 and FLAG = 999999 order by round desc
select COUNT(*) as aa, a7 from TestOutput where FLAG =999999 group by A7 order by aa desc
select COUNT(*) as aa, a7 from TestOutput where FLAG =999999 group by A7 order by a7 desc
/*upup*/select * from TestOutput where FLAG = 999999 and A7 >= 7 and A7<=40
select COUNT(*) as aa, a8 from TestOutput where FLAG =999999 group by A8 order by a8 desc
select COUNT(*) as aa, a9 from TestOutput where FLAG =999999 group by A9 order by aa desc
select COUNT(*) as aa, a9 from TestOutput where FLAG =999999 group by A9 order by a9 desc
/*sum30*/select * from TestOutput where FLAG = 999999 and A9 >= 24 and A9<=42
select * from TestOutput where FLAG = 999999 and A8 >=13
select * from TestOutput where FLAG = 999999 and A8 <=3
select * from TestOutput where FLAG=999999 and A7 <=6
select * from TestOutput where FLAG=999999 and A7 >=60 order by a7
select COUNT(*) as aa, a6 +a7 from TestOutput where FLAG =999999 group by A6+a7 order by a6+a7 desc

select COUNT(*) as aa, A10,a11 from TestOutput where FLAG =999999 group by A10,a11 order by a10,A11-a10
select COUNT(*) as aa, A11-a10 from TestOutput where FLAG =999999 group by A11-a10 order by aa  desc
select COUNT(*) as aa, A10,a11 from TestOutput where FLAG =99999900 group by A10,a11 order by a10,A11-a10
select COUNT(*) as aa, A10,a11, A11-a10 from TestOutput where FLAG =99999900 group by A10,a11 order by aa desc
select COUNT(*) as aa, A11-a10 from TestOutput where FLAG =99999900 group by A11-a10 order by aa  desc

/**/select * from TestOutput where FLAG = 999999 and A10 = 0 and A11 = 9 and ROUND in (select round from TestOutput where FLAG=99999900 and A10 = 4 and A11 = 7)
/**/select COUNT(*) as aa, A10,a11, A11-a10 from TestOutput where FLAG =999999  and ROUND in (select round from TestOutput where FLAG=99999900 and A10 >= 3 and A11 <= 8) group by A10,a11 order by aa desc
/*sum-2 && upup0-10 && sum30 3-8*/select abs(a0-(select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) as bb, * from TestOutput as nn where nn.FLAG = 999999 and nn.A10 = 0 and nn.A11<=10 and nn.ROUND in (select round from TestOutput where FLAG=99999900 and A10 >= 3 and A11 <= 8) 
/*and (a6 <= 30 and a6 >= 21) -- a6-a1
and A28 in ('b2b2c2', 'a2b2c2','a2c4', 'b2c4','c6')
and (A27 like '5%' or A27 like '4%' ) 
and (A3 = 2 or A3 = 3 or A3 = 4) --16
and (A4 = 2 or A4 = 3 or A4 = 4)--22
and (A5 = 2 or A5 = 3 or A5 = 4)--28*/
--and A26 = 'BBBBBB'
--and A4=0 and A5<=10 --min m
order by bb
/*sum-2 && upup0-10 && sum30 3-8*/select COUNT(*)as aa, cc.bb from
(select abs(a0-(select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) as bb, * from TestOutput as nn where nn.FLAG = 999999 and nn.A10 = 0 and nn.A11<=10 and nn.ROUND in (select round from TestOutput where FLAG=99999900 and A10 >= 3 and A11 <= 8) 
and (a6 <= 30 and a6 >= 21) -- a6-a1
and A28 in ('b2b2c2', 'a2b2c2','a2c4', 'b2c4','c6')
and (A27 like '5%' or A27 like '4%' ) 
and (A3 = 2 or A3 = 3 or A3 = 4) --16
and (A4 = 2 or A4 = 3 or A4 = 4)--22
and (A5 = 2 or A5 = 3 or A5 = 4)--28
--and ROUND in (select ROUND from TestOutput where FLAG = 44444433 and A2 <= 4)
and A26 = 'BBBBBB'
and len(A29)=11
--and A4=0 and A5<=10 --min m
) cc group by cc.bb order by aa desc 

select * from TestOutput where FLAG = 44444433 and A2 <= 4

select COUNT(*) as aa, a14,a15 from TestOutput where FLAG =999999 group by A14,a15 order by aa desc
select COUNT(*) as aa, a15 from TestOutput where FLAG =999999 group by A15 order by aa desc
select COUNT(*) as aa, a17 from TestOutput where FLAG =999999 group by A17 order by aa desc
select COUNT(*) as aa, a19 from TestOutput where FLAG =999999 group by A19 order by aa desc

select * from TestOutput where FLAG=999999 and A14 not like '%half%'
select * from TestOutput where FLAG=999999 and A15 in (3,4,5) and A17 in (3,4,5) and A19 in (3,4,5)
select * from TestOutput where FLAG=999999 and A15 in (4,5) and A17 in (4,5) and A19 in (4,5)
select * from TestOutput where FLAG=999999 and A15 in (3,4) and A17 in (3,4) and A19 in (3,4)
select COUNT(*) as aa, a15,A17 from TestOutput where FLAG =999999 group by A15,A17 order by aa desc
select COUNT(*) as aa, a15,A17,a19 from TestOutput where FLAG =999999 group by A15,A17,a19 order by aa desc

select COUNT(*) as aa, a15,A17,a19 from TestOutput where 
FLAG =999999 and A15 in (3,4,5) and A17 in (3,4,5) and A19 in (3,4,5)
and A15+ A17 +A19 = 12
group by A15,A17,a19 order by aa desc
select COUNT(*) as aa, a15,A17,a19 from TestOutput where FLAG =999999 and A15 in (3,4,5) and A17 in (3,4,5) and A19 in (3,4,5)
group by A15,A17,a19 order by aa desc
select COUNT(*) as aa, a15,A17,a19 from TestOutput where FLAG =999999 and A15 in (4,5) and A17 in (4,5) and A19 in (4,5)
group by A15,A17,a19 order by aa desc
select COUNT(*) as aa, a15,A17,a19 from TestOutput where FLAG =999999 and A15 in (3,4) and A17 in (3,4) and A19 in (3,4)
group by A15,A17,a19 order by aa desc

select COUNT(*) as aa, a13 from TestOutput where FLAG =999999 group by A13 order by aa desc

select (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) as bb ,* from TestOutput as nn where 
abs(A0 - (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) =2 and flag = 999999
and (A3 = 3 or A3 = 2 or A3 =1 or A3 = 4)
and a1 < 3
order by ROUND desc

/*sum-2*/select *, abs(A0 - b.bb) from (select (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) as bb ,* from TestOutput as nn where 
abs(A0 - (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) <= 35 and flag = 999999
)as b  
/*sum-2*/select count(*)as aa, abs(A0 - b.bb) from (select (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) as bb ,* from TestOutput as nn where 
abs(A0 - (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) <= 50 and flag = 999999
)as b group by abs(A0 - b.bb) order by aa desc
/*sum-2*/select * from (select (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) as bb ,* from TestOutput as nn where 
abs(A0 - (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) = 2 and flag = 999999
)as b 
/*sum-2 && upup0-10 && sum30 3-8*/select * from (select (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) as bb ,* from TestOutput as nn where 
abs(A0 - (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2)) <= 5 and flag = 999999 and ROUND in
(select round from TestOutput where FLAG = 999999 and A10 = 0 and A11<=10 and ROUND in (select round from TestOutput where FLAG=99999900 and A10 >= 3 and A11 <= 8))
)as b 


select count(*)as aa, A0 - b.bb from (select (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) as bb ,* from TestOutput as nn where 
--A0 - (select A0 from TestOutput where flag = 999999 and id = nn.ID - 2) <= 10 and 
flag = 999999
)as b group by A0 - b.bb order by aa desc


select a0,(select A0 from TestOutput where  flag = 999999 and id = nn.ID - 2),A0 - (select A0 from TestOutput where flag = 999999 and  id = nn.ID - 2),ID, round from TestOutput as nn where 
  flag = 999999
order by ROUND desc

select * from TestOutput as nn where 
A1 <> (select A1 from TestOutput where id = nn.ID - 1)
and A2 <> (select A2 from TestOutput where id = nn.ID - 1)
order by ROUND desc

select * from TestOutput as nn where 
A1 = (select A1 from TestOutput where id = nn.ID - 1)
and A2 = (select A2 from TestOutput where id = nn.ID - 1)
order by ROUND desc

select * from TestOutput as nn where 
A1 = (select A1 from TestOutput where id = nn.ID - 2)
and A2 = (select A2 from TestOutput where id = nn.ID - 2)
order by ROUND desc

select * from TestOutput as nn where 
A1 = (select A1 from TestOutput where id = nn.ID - 3)
and A2 = (select A2 from TestOutput where id = nn.ID - 3)
order by ROUND desc

select * from TestOutput as nn where 
A1 = (select A1 from TestOutput where id = nn.ID - 4)
and A2 = (select A2 from TestOutput where id = nn.ID - 4)
order by ROUND desc

select * from TestOutput as nn where 
A1 = (select A1 from TestOutput where id = nn.ID - 5)
and A2 = (select A2 from TestOutput where id = nn.ID - 5)
order by ROUND desc

select * from TestOutput as nn where 
A1 = (select A1 from TestOutput where id = nn.ID - 6)
and A2 = (select A2 from TestOutput where id = nn.ID - 6)
order by ROUND desc