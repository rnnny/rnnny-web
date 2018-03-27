--delete from TestOutput
--delete from TestOutput where FLAG=77887788
--delete from TestOutput where FLAG=778877
--delete from TestOutput where FLAG=778888


--TestNew
select * from TestOutput where FLAG=777788

select COUNT(*) as aa, a0 from TestOutput where FLAG=777788 group by A0 order by aa desc
select COUNT(*) as aa, a0 from TestOutput where FLAG=777788 and A4 >= 5 group by A0 order by aa desc

select COUNT(*) as aa, a1 from TestOutput where FLAG=777788 group by A1 order by aa desc
select COUNT(*) as aa, a1 from TestOutput where FLAG=777788 and A4 >= 5 group by A1 order by aa desc

select COUNT(*) as aa, a2 from TestOutput where FLAG=777788 group by A2 order by aa desc
select COUNT(*) as aa, a2 from TestOutput where FLAG=777788 and A4 >= 5 group by A2 order by aa desc

select COUNT(*) as aa, a3 from TestOutput where FLAG=777788 group by A3 order by aa desc
select COUNT(*) as aa, a3 from TestOutput where FLAG=777788 and A4 >= 5 group by A3 order by aa desc

select COUNT(*) as aa, a4 from TestOutput where FLAG=777788 group by A4 order by aa desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=777788 group by A12 order by aa desc

select * from TestOutput where FLAG=777788 and (A12 like '%00' or A12 like '%01' or A12 like '%10')
select * from TestOutput where FLAG=777788 and (A12 like '%20' or A12 like '%11' or A12 like '%02')

select COUNT(*) as aa from TestOutput where FLAG=777788 and A4 >= 5  and A12 not like '%5%'and A12 not like '%4%'and A12 not like '%3%'
select COUNT(*) as aa, a12,a4 from TestOutput where FLAG=777788 and A4 >= 4 group by A12,a4 order by aa,a4 desc
select COUNT(*) as aa from TestOutput where FLAG=777788 and A12 not like '%3%' and A12 not like '%4%' and A12 not like '%5%'
select COUNT(*) as aa from TestOutput where FLAG=777788 and A4 >= 6 and A12 like '%0%'

select COUNT(*) as aa, A5 from TestOutput where FLAG=777788 and A4 >= 5 group by a5 order by aa desc


select COUNT(*) as aa, a12 from TestOutput where FLAG=777788 and A4 >= 6 group by A12 order by aa desc
select COUNT(*) as aa, a13 from TestOutput where FLAG=777788 group by A13 order by aa desc

select COUNT(*) as aa, a14 from TestOutput where FLAG=777788 group by A14 order by aa desc
select COUNT(*) as aa from TestOutput where FLAG=777788 and A14 not like '%2%'


--Test
select * from TestOutput where FLAG=778888

/*four*/select * from (select COUNT(*) as aa, a12 from TestOutput where FLAG=778888 
group by A12)as haha  where aa >=10 order by aa desc

/*six*/select * from TestOutput where FLAG=778877 
--and A12 not like '%24%'
order by a1 desc

/*six*/select * from TestOutput where FLAG=778877 and A12 like'%15%' and A12 like '%28%'
and ((a13>=80 and A13 <= 100) or(A13 <=120 and A13 >=110))
order by a1 desc

select * from TestOutput where FLAG=77887788 order by a1
select * from TestOutput where FLAG=778877 and A12 like '%09%'and A12 like '%21%'and A12 like '%27%'and A12 like '%30%'and A12 like '%30%'
select * from TestOutput where FLAG=778877 order by a13 desc
select top  6 * from TestOutput where FLAG=778877 order by a1 desc
select COUNT(*) as aa, a12 from TestOutput where FLAG=778877 group by A12 order by aa desc


/*six*/select * from TestOutput where FLAG = 666666 and A12 in(select top 204 a12 from TestOutput where FLAG=778877 order by a1 desc)
--and (A9=2 or A10 =2)
and A30<='20' and ROUND <='25'
and A13 like '%|5*5-5%'
and A12 like '%03%' and A12 like '%12%'
and (A8 >= 115 or A8 <= 75)
and A29 = '200020'
 
 
 --and A12 like '%30%'
 
 --and a12 like '%10%' and A12 not like '%11%'
 and A8 <=100  --and A8 <= 125
 and A29 = '000000'
 and A11 = 3
 
 and A23 not like '%4%' and A23 not like '%3%'
 
 order by a12
 
 
/*01|02|07|16|27|30
03|07|08|15|20|24
01|04|05|14|16|25
02|05|07|15|16|24
05|07|08|14|16|27
03|04|07|08|16|29
02|03|08|19|20|27
03|06|07|14|20|25
01|02|07|18|24|25
03|04|08|14|19|25
01|05|16|19|20|30
06|07|14|15|16|19
03|05|06|16|18|29
03|05|08|16|24|25
03|05|14|15|24|30
03|04|06|16|25|31
04|05|09|10|16|29
01|03|08|18|19|30
01|07|08|14|24|31
02|03|05|16|26|27
01|03|08|20|28|29
01|03|04|09|20|30
01|06|15|18|19|26
03|04|09|16|18|19
01|05|14|15|20|28
03|07|14|15|18|28
05|06|10|14|25|31
01|04|08|15|19|20
01|02|07|09|20|28
01|02|09|10|19|26
03|09|10|14|19|30
05|10|14|15|18|19*/