--delete from TestOutput
--delete from TestOutput where flag = 666666

select * from TestOutput where FLAG = 66666688 and A12 like '%20%' and A12 like '%22%' and A12 like '%26%' and A12 like '%27%' and A6>=130
select * from TestOutput where FLAG = 66666688 --and A2 <= 100 --and A2 >= 100 
--and A12 like '%27|33%' 
--and A12 like '%10%' --and A12 like '%18%'
--and (ROUND <= '30' and ROUND >= '21') -- a6-a1
--and A13 is not null
--and (A13 = 13 or A13 = 23 or A13 = 33)
--and A12 not like '%33%' and A12 not like '%24%' and A12 not like '%15%'
--and A12 not like '%28%' and A12 not like '%11%' and A12 not like '%31%'
--and A12 not like '%23%' and A12 not like '%21%' and A12 not like '%09%'
--and A12 not like '%29%' 
--and A12 not like '%25%' 
and A25 in ('b2b2c3', 'a2b2c3','a2c5', 'b2c5')--,'c7')
and (
--A23 like '5%' or A23 like '4%' 
--or 
A23 like '6%'
) 
and (A9 = 2 or A9 = 3 or A9 = 4) --16
and (A10 = 2 or A10 = 3 or A10 = 4)--22
and (A11 = 2 or A11 = 3 or A11 = 4)--28
and A26 = 'BBBBBB'
and A4=0 and A5<=10 --min max
and A2>=24 and A2<=42
and A3>=7 and A3<=40
-------------------------
--and (a27 like '%00000%' or a27 like '%11111%' or a27 like '%22222%')
--and A9 = 3 and A10=3 
--and (A25 ='a2c5' or A25='b2c5' )
--and A6 = 73

--and A10 = 2 and A11 = 3 and A7 = 2 and A9 = 3 
--order by a2 desc
and A6>=109 and A6<123
order by A3 desc


select * from TestOutput where FLAG = 66666688 and A13 = 13 --and A13 =13 --order by A2 desc --and A13 = 34
--and A2 >= 100 and A2 <= 200
--and A10 = 2 and A11 = 3 and A7 = 2 and A9 = 3 
and A12 like '%25%' and A12 like '%26%' and A12 like'%30%' --and A12 like'%27%'
--and A12 not like '%30%' and A12 not like '%31%' and A12 not like '%32%'
--and A12 not like '%33%' and A12 not like '%28%' 
--and A12 not like '%10%' and A12 not like '%11%' 
--and A12 not like '%12%' and A12 not like '%13%' and A12 not like '%20%'
and (ROUND <= '30' and ROUND >= '21') -- a6-a1
--and A13 is not null
--and A13 = 14
and A25 in ('b2b2c2', 'a2b2c2','a2c4', 'b2c4','c6')
and (
A23 like '5%' or A23 like '4%' 
--or A23 like '6%'
) 
and (A9 = 2 or A9 = 3 or A9 = 4) --16
and (A10 = 2 or A10 = 3 or A10 = 4)--22
and (A11 = 2 or A11 = 3 or A11 = 4)--28
and (A26 = 'BBBBBB' or A26 = 'ABBBBB' or A26 = 'BBBBBC' or A26='ABBBBC')
order by A2 desc


select COUNT(*) from TestOutput where flag = 666666
select COUNT(*), flag from TestOutput group by flag
select COUNT(*) from TestOutput where flag<> 666666
select COUNT(*) from TestOutput where A13 like '%ok' or A13 like '%-ok4'or A13 like '%|ok4'

/**/update TestOutput set a23 = 'oo' where a23 = 'ok'
and a15 in (select a22 from TestOutput where FLAG = 2) and flag = 666666
/**/update TestOutput set a23 = 'oo' where a23 = 'ok'
and a16 in (select a22 from TestOutput where FLAG = 3) and flag = 666666
/**/update TestOutput set a23 = 'oo' where  a23 = 'ok'
and a17 in (select a22 from TestOutput where FLAG = 4) and flag = 666666
/**/update TestOutput set a23 = 'oo' where  a23 = 'ok'
and a18 in (select a22 from TestOutput where FLAG = 5) and flag = 666666
/**/update TestOutput set a23 = 'oo' where  a23 = 'ok'
and a19 in (select a22 from TestOutput where FLAG = 6) and flag = 666666
/**/update TestOutput set a23 = 'oo' where  a23 = 'ok'
and a20 in (select a22 from TestOutput where FLAG = 7) and flag = 666666
/**/update TestOutput set a23 = 'oo' where  a23 = 'ok'
and a21 in (select a22 from TestOutput where FLAG = 8) and flag = 666666

/**/update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and a23 = 'ok'
and a22 in (select a22 from TestOutput where FLAG = 9)



/**/update TestOutput set a23 = 'oo' where a15 in (select a22 from TestOutput where FLAG = 2)
/**/update TestOutput set a23 = 'oo' where a16 in (select a22 from TestOutput where FLAG = 3)
/**/update TestOutput set a23 = 'oo' where a17 in (select a22 from TestOutput where FLAG = 4)
/**/update TestOutput set a23 = 'oo' where a18 in (select a22 from TestOutput where FLAG = 5)
/**/update TestOutput set a23 = 'oo' where a19 in (select a22 from TestOutput where FLAG = 6)
/**/update TestOutput set a23 = 'oo' where a20 in (select a22 from TestOutput where FLAG = 7)
/**/update TestOutput set a23 = 'oo' where a21 in (select a22 from TestOutput where FLAG = 8)
/**/update TestOutput set a23 = 'oo' where a22 in (select a22 from TestOutput where FLAG = 9)

select * from  TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a21 in (select a22 from TestOutput where FLAG = 8)

/**/select COUNT(*) as a13ok4 from TestOutput where A13 like '%ok4%'
/**/select COUNT(*) as a13ok from TestOutput where A13 like '%ok'
/**/select COUNT(*) as a14ok from TestOutput where A14 = 'ok'
/**/select COUNT(*) as ok from TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
/**/select COUNT(*) as a8ok from TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and (A8 >= 60 and A8<= 129)
/**/select COUNT(*) as a131423ok from TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and A23 = 'ok' and (A8 >= 60 and A8<= 129)
/**/select COUNT(*) as a131423ok from TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and A23 = 'ok' and (A8 >= 60 and A8<= 129)
and A9 <> 1 and A9 <> 3
and A10 <> 4 and A10 <> 1 and A10 <> 2 and A10 <> 3
and A11 <> 2

select * from TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and (A8 >= 100 and A8<= 110) order by a12


select * from TestOutput where A12 like '%14%' and A12 like '%17%' and   A12 like '%05%' and A12 like '%19%'and A12 like '%22%' and A12 like '%02%'and (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'   order by a12

/**/select * from TestOutput where   A12 like '%05%' and A12 like '%08%'and A12 like '%09%'  and  (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and A23 = 'ok' order by a12


/**/select * from TestOutput where    
--A12 like '%08%' 
--A12 like '%27|28|29%'
--and A12 like '%27%' 
--and A12 like '%22%'
--and A12 like '%30%' --or A12 like '%13|14|16%' or A12 like '%14|15|17%' or A12 like '%13|15|17%') --and A12 like '%20%' 
--and 
--A12 like '%19|24%' 
--and 
--A12 like '%10' 
--and A12 like '%08%' 
--and 
A12 not like '%31%' and A12 not like '%02%' and A12 not like '%06%'
--and A12 not like '%03%' and A12 not like '%06%' 
--and A12 not like '%03%' and A12 not like '%04%' 
and A12 not like '%01%' and A12 not like '%21%' and A12 not like '%15%'
--and A12 not like '%27%' and A12 not like '%06%' and A12 not like '%02%'
--and A12 not like '%02%' 
--and A12 not like '%11%' and A12 not like '%17%'
and A12 not like '%33%' and A12 not like '%17%'and A12 not like '%27%'
--and A12 not like '%27%' and A12 not like '%28%' 
--and A12 not like '%19%' and A12 not like '%25%' 
--and A12 not like '%28%' and A12 not like '%32%'
--and A12 not like '%26%'and A12 not like '%27%'
--and A10=5 
--and A9 <> a10
--and
--a24 like '%1%' and a24 like '%9%' and a24 like '%6%' and a24 like '%0%' and a24 like '%2%' 
--and A12 not like '%12%'
--and --A11 = 1 --A25 not like '%a%'
--and (A25 = '%a3%')-- or A25 = 'b2b2c3')
and
FLAG = 666666 --and A10=0 and A11 = 1--and A13 not like '%-5%'
and (
A23 like '5%' or A23 like '4%'-- or 
--A23 like '6%'
) 
and A13 like '%-5%'
and A13 like '%*5%' 
and A13 like '%|5%'
--and (A13 like '%*5%' or A13 like '%|5%')--and A11 = 2
and (A14 like '%_1' or A14 like '%_2' or A14 like '%_3')
--and A13 like '%-5%'
--and A23 like '%0%'
--and (A29 = '000002' or A29 = '000020')
--and (A23 = 'ok' or (A23='oo' and (A26 =4 or a26 = 5))) 
--and A26 in ('1', '2')
--and A24 = '2'--A24 upCount
and  (A8>=90 and A8 <= 110) --or (A8>=110 and A8 <=120)) --or 
--and A8<93 
and A27 <> ''
--and A27 like '%UpUp%'
--and ((A8  >= 100 and A8 <= 110) or (A8 >= 120))
and (ROUND <= '30' and ROUND >= '21') -- a6-a1
--and ROUND in ('19', '20')
--and A30 in ('49','50')
--and A8 / 10 <> 9
--a9 22 a10 16 a11 28 
--and A10 = 5  and A9 = 4 --and A10 = 4
and A25 in ('b2b2c2', 'a2b2c2','a2c4', 'b2c4','c6')
and A16 like '%4%'
and (A9 = 2 or A9 = 3 or A9 = 4) --16
and (A10 = 2 or A10 = 3 or A10 = 4)--22
and (A11 = 2 or A11 = 3 or A11 = 4)--28
--and A9 = 3 --16
--and A10 = 3 --22
--and A11 = 4 --28
--and A26 = 5
--and a30 <= '15' -- upup
--and A29 = '000000'
--and (a23 like '6_3%' or a23 like '6_2%')

and A9 <> 6 and A9 <> 1 and A9 <> 0 --16
and A10 <> 6 and A10 <> 0 and A10 <> 5 --22
and A11 <> 6 and A11 <> 0 and A11 <> 5 --28
order by a12,a8,a26

/**/select * from TestOutput where    
--A12 like '%05%' and A12 like '%08%' and A12 like '%18%'
--and 
FLAG = 666666 order by A8 desc

/*test a9==0 a9==6*/select * from TestOutput where  
A12 not like '%31%' and A12 not like '%02%' and A12 not like '%06%'
--and A12 not like '%03%' and A12 not like '%06%' 
--and A12 not like '%03%' and A12 not like '%04%' 
and A12 not like '%01%' and A12 not like '%21%' and A12 not like '%15%'
--and A12 not like '%27%' and A12 not like '%06%' and A12 not like '%02%'
--and A12 not like '%02%' 
--and A12 not like '%11%' and A12 not like '%17%'
and A12 not like '%33%' and A12 not like '%17%'and A12 not like '%27%'
and (A8>93 and A8 < 103)
--and A30< 20
--and A11 <=2 and A8 <=75
and
FLAG = 666666 
and A9 = 3 and A10 = 2 and A11 = 3 and A17 = 2
--and (A9 = 6 or A9 =0) and A9 <> a10
--and (A9 +A10 +A11 >= 13 or A9 + A10 +A11 <=3)
and A25 in ('b2b2c2', 'a2b2c2','a2c4', 'b2c4','c6')
and A16 like '%4%'
and (A14 like '%_1' or A14 like '%_2' or A14 like '%_3')
and A27 <> ''
and (
A23 like '5%' or A23 like '4%' or 
A23 like '6%'
) 


/*test*/select * from TestOutput where  
FLAG = 666666  
-----------------------------------
and (A8>=90 and A8 <= 100)
--and ROUND <= '18'  -- a6-a1
and A30 <= '30'--upup
and A9 = 2--16 two
and A10 = 3--22 prime
and A11 = 4--28 nearRepeat
---------------------------------------
and (
A23 like '5%' or A23 like '4%' or 
A23 like '6%'
) 
and A13 like '%-5%'
and A13 like '%*5%' 
and (A14 like '%_1' or A14 like '%_2' or A14 like '%_3')
and A25 in ('b2b2c3', 'a2b2c3','a2c5', 'b2c5')
and A16 like '%4%'
and A27 <> ''

order by a12,a8,a26

select * from TestOutput where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' and A23 = 'ok' and A24 = 'ok' and A8>= 60 and A8<= 69 order by a12


update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok' 
and a15 in (select a22 from TestOutput where FLAG = 2)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a16 in (select a22 from TestOutput where FLAG = 3)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a17 in (select a22 from TestOutput where FLAG = 4)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a18 in (select a22 from TestOutput where FLAG = 5)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a19 in (select a22 from TestOutput where FLAG = 6)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a20 in (select a22 from TestOutput where FLAG = 7)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a21 in (select a22 from TestOutput where FLAG = 8)
update TestOutput set a23 = 'oo' where (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'
and a22 in (select a22 from TestOutput where FLAG = 9)

/**/select * from TestOutput where A12 like '%03%' and A12 like '%20%' and A12 like '%09%'and A12 like '%15%' and (A13 like '%ok' or A13 like '%ok4%') and A14 = 'ok'   order by a12

select COUNT(*) from TestOutput where A13 like '%oo%'
select COUNT(*) from TestOutput where A13 like '%-ok4%'
select COUNT(*) from TestOutput where A13 like '%*ok4%'
select COUNT(*) from TestOutput where A13 like '%|ok4%'
select COUNT(*) from TestOutput where A13 like '%-4'
select COUNT(*) from TestOutput where A13 like '%*4'
select COUNT(*) from TestOutput where A13 like '%|4'
select * from TestOutput where A13 like '%|ok4'
select * from TestOutput where A13 like '%_ok4'
select* from TestOutput where  A12 like '%07%' and A12 like '%14%' and A12 like '%15%' and A13 like '%ok%'order by a8 
select* from TestOutput where  A12 like '%27%' and A12 like '%28%' and A13 like '%ok%'order by a8
select* from TestOutput where  A12 like '%27%' and A12 like '%28%' and A13 like '%ok'order by a8

select* from TestOutput where  A12 like '%06%' and A12 like '%07%' and A12 like '%10%'  and A12 like '%14%' and A12 like '%22%'
select* from TestOutput where  A12 like '%24%' and A12 like '%25%' and A12 like '%25%' and a13 like '%ok' order by a8 
select* from TestOutput where a8 >= 70 and a8 <= 90 order by a8 desc
select* from TestOutput where A12 = '01|04|08|09|14|15'
select* from TestOutput where FLAG = 666666 and A12 like '%01%' and A12 like'%08%' and A12 like '%09%' and A12 like '%14%' and A12 like '%15%'

select
(select COUNT(*) from TestOutput where  A12 like '%01%' and( A13 like '%ok' or A13 like '%ok4%')) as a01,
(select COUNT(*) from TestOutput where  A12 like '%02%' and (A13 like '%ok' or A13 like '%ok4%'))as a02,
(select COUNT(*) from TestOutput where  A12 like '%03%' and (A13 like '%ok' or A13 like '%ok4%'))as a03,
(select COUNT(*) from TestOutput where  A12 like '%04%' and (A13 like '%ok' or A13 like '%ok4%'))as a04,
(select COUNT(*) from TestOutput where  A12 like '%05%' and (A13 like '%ok' or A13 like '%ok4%'))as a05,
(select COUNT(*) from TestOutput where  A12 like '%06%' and (A13 like '%ok' or A13 like '%ok4%'))as a06,
(select COUNT(*) from TestOutput where  A12 like '%07%' and (A13 like '%ok' or A13 like '%ok4%'))as a07,
(select COUNT(*) from TestOutput where  A12 like '%08%' and (A13 like '%ok' or A13 like '%ok4%'))as a08,
(select COUNT(*) from TestOutput where  A12 like '%09%' and( A13 like '%ok' or A13 like '%ok4%')) as a09,
(select COUNT(*) from TestOutput where  A12 like '%10%' and (A13 like '%ok' or A13 like '%ok4%'))as a10,
(select COUNT(*) from TestOutput where  A12 like '%11%' and( A13 like '%ok' or A13 like '%ok4%')) as a11,
(select COUNT(*) from TestOutput where  A12 like '%12%' and (A13 like '%ok' or A13 like '%ok4%'))as a12,
(select COUNT(*) from TestOutput where  A12 like '%13%' and (A13 like '%ok' or A13 like '%ok4%'))as a13,
(select COUNT(*) from TestOutput where  A12 like '%14%' and (A13 like '%ok' or A13 like '%ok4%'))as a14,
(select COUNT(*) from TestOutput where  A12 like '%15%' and (A13 like '%ok' or A13 like '%ok4%'))as a15,
(select COUNT(*) from TestOutput where  A12 like '%16%' and (A13 like '%ok' or A13 like '%ok4%'))as a16,
(select COUNT(*) from TestOutput where  A12 like '%17%' and (A13 like '%ok' or A13 like '%ok4%'))as a17,
(select COUNT(*) from TestOutput where  A12 like '%18%' and (A13 like '%ok' or A13 like '%ok4%'))as a18,
(select COUNT(*) from TestOutput where  A12 like '%19%' and( A13 like '%ok' or A13 like '%ok4%')) as a19,
(select COUNT(*) from TestOutput where  A12 like '%20%' and (A13 like '%ok' or A13 like '%ok4%'))as a20,
(select COUNT(*) from TestOutput where  A12 like '%21%' and( A13 like '%ok' or A13 like '%ok4%')) as a21,
(select COUNT(*) from TestOutput where  A12 like '%22%' and (A13 like '%ok' or A13 like '%ok4%'))as a22,
(select COUNT(*) from TestOutput where  A12 like '%23%' and (A13 like '%ok' or A13 like '%ok4%'))as a23,
(select COUNT(*) from TestOutput where  A12 like '%24%' and (A13 like '%ok' or A13 like '%ok4%'))as a24,
(select COUNT(*) from TestOutput where  A12 like '%25%' and (A13 like '%ok' or A13 like '%ok4%'))as a25,
(select COUNT(*) from TestOutput where  A12 like '%26%' and (A13 like '%ok' or A13 like '%ok4%'))as a26,
(select COUNT(*) from TestOutput where  A12 like '%27%' and (A13 like '%ok' or A13 like '%ok4%'))as a27,
(select COUNT(*) from TestOutput where  A12 like '%28%' and (A13 like '%ok' or A13 like '%ok4%'))as a28,
(select COUNT(*) from TestOutput where  A12 like '%29%' and( A13 like '%ok' or A13 like '%ok4%')) as a29,
(select COUNT(*) from TestOutput where  A12 like '%30%' and (A13 like '%ok' or A13 like '%ok4%'))as a30,
(select COUNT(*) from TestOutput where  A12 like '%31%' and( A13 like '%ok' or A13 like '%ok4%')) as a31,
(select COUNT(*) from TestOutput where  A12 like '%32%' and (A13 like '%ok' or A13 like '%ok4%'))as a32,
(select COUNT(*) from TestOutput where  A12 like '%33%' and (A13 like '%ok' or A13 like '%ok4%'))as a33
select
(select COUNT(*) from TestOutput where  A12 like '%01%' and A13 like '%ok' ) as a01,
(select COUNT(*) from TestOutput where  A12 like '%02%' and A13 like '%ok' )as a02,
(select COUNT(*) from TestOutput where  A12 like '%03%' and A13 like '%ok' )as a03,
(select COUNT(*) from TestOutput where  A12 like '%04%' and A13 like '%ok' )as a04,
(select COUNT(*) from TestOutput where  A12 like '%05%' and A13 like '%ok' )as a05,
(select COUNT(*) from TestOutput where  A12 like '%06%' and A13 like '%ok' )as a06,
(select COUNT(*) from TestOutput where  A12 like '%07%' and A13 like '%ok' )as a07,
(select COUNT(*) from TestOutput where  A12 like '%08%' and A13 like '%ok' )as a08,
(select COUNT(*) from TestOutput where  A12 like '%09%' and A13 like '%ok' ) as a09,
(select COUNT(*) from TestOutput where  A12 like '%10%' and A13 like '%ok' )as a10,
(select COUNT(*) from TestOutput where  A12 like '%11%' and A13 like '%ok' ) as a11,
(select COUNT(*) from TestOutput where  A12 like '%12%' and A13 like '%ok' )as a12,
(select COUNT(*) from TestOutput where  A12 like '%13%' and A13 like '%ok' )as a13,
(select COUNT(*) from TestOutput where  A12 like '%14%' and A13 like '%ok' )as a14,
(select COUNT(*) from TestOutput where  A12 like '%15%' and A13 like '%ok' )as a15,
(select COUNT(*) from TestOutput where  A12 like '%16%' and A13 like '%ok' )as a16,
(select COUNT(*) from TestOutput where  A12 like '%17%' and A13 like '%ok' )as a17,
(select COUNT(*) from TestOutput where  A12 like '%18%' and A13 like '%ok' )as a18,
(select COUNT(*) from TestOutput where  A12 like '%19%' and A13 like '%ok' ) as a19,
(select COUNT(*) from TestOutput where  A12 like '%20%' and A13 like '%ok' )as a20,
(select COUNT(*) from TestOutput where  A12 like '%21%' and A13 like '%ok' ) as a21,
(select COUNT(*) from TestOutput where  A12 like '%22%' and A13 like '%ok' )as a22,
(select COUNT(*) from TestOutput where  A12 like '%23%' and A13 like '%ok' )as a23,
(select COUNT(*) from TestOutput where  A12 like '%24%' and A13 like '%ok' )as a24,
(select COUNT(*) from TestOutput where  A12 like '%25%' and A13 like '%ok' )as a25,
(select COUNT(*) from TestOutput where  A12 like '%26%' and A13 like '%ok' )as a26,
(select COUNT(*) from TestOutput where  A12 like '%27%' and A13 like '%ok' )as a27,
(select COUNT(*) from TestOutput where  A12 like '%28%' and A13 like '%ok' )as a28,
(select COUNT(*) from TestOutput where  A12 like '%29%' and A13 like '%ok' ) as a29,
(select COUNT(*) from TestOutput where  A12 like '%30%' and A13 like '%ok' )as a30,
(select COUNT(*) from TestOutput where  A12 like '%31%' and A13 like '%ok' ) as a31,
(select COUNT(*) from TestOutput where  A12 like '%32%' and A13 like '%ok' )as a32,
(select COUNT(*) from TestOutput where  A12 like '%33%' and A13 like '%ok' )as a33