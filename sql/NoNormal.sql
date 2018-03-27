
--delete from TestOutput
select COUNT(*) from TestOutput
select * from TestOutput where FLAG='444555' and A14 > '0.75'
select * from TestOutput where FLAG='444444' order by round
select * from TestOutput where FLAG='444555' 

select * from TestOutput where FLAG = 444444 and A0 /10 = A6 /10

select COUNT(*)as aa, a3 from TestOutput where FLAG='444444' group by A3 order by A3 
select COUNT(*)as aa from TestOutput where A3 <= 4 and FLAG='444444'
select COUNT(*)as aa from TestOutput where A3 > 4 and A3 <= 7 and FLAG='444444'
select COUNT(*)as aa from TestOutput where A3 > 7 and FLAG='444444'

select COUNT(*) as aa, a7 from TestOutput where FLAG='444555' group by A7 order by a7
select COUNT(*) as aa, a8 /10 from TestOutput where FLAG='444555' group by A8 / 10 order by a8 /10
select COUNT(*) as aa, a0 from TestOutput where FLAG='444555' group by A0 order by a0
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG='444555' group by A0 ) as bb
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG='444555' group by A0 having a0 <= 30 ) as bb

select COUNT(*) as aa, a12 from TestOutput where FLAG='444444' group by a12 order by aa desc
select * from TestOutput where FLAG='444444' and A1+A2>=4
select COUNT(*) as aa, a12 from TestOutput where FLAG='444444' and A12 not like '3%' and A12 not like '%4%' and A12 not like '%5%' group by a12 order by aa desc
select sum(bb.aa) from (select COUNT(*) as aa from TestOutput where FLAG='444444'and A12 not like '3%' and A12 not like '%4%' and A12 not like '%5%' group by a12) as bb
select COUNT(*) as aa, a1 from TestOutput where FLAG='444444' group by a1 order by aa desc


select COUNT(*) as aa, a2 from TestOutput where FLAG='444444' group by a2 order by aa desc


select * from TestOutput where FLAG = 888888
select COUNT(*) as aa, A12, a14 from TestOutput where FLAG = '888888' and A11 =6 group by A12, a14 order by a12

select * from TestOutput where FLAG = '888888' and A11 =6 order by a10 desc

select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =3
select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =2 and A12 like '%' +a14 + '%' 
select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =2 and A15 like '%' +a17 + '%'

select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =2 and A18 like '%' +a20 + '%' 
select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =2 and A21 like '%' +a23 + '%' 

select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =2 and A24 like '%' +a26 + '%' 
select COUNT(*) as aa from TestOutput where FLAG = '888888' and A11 =6 and A27 like '%' +a29 + '%' 

select COUNT(*) as aa, a16 from TestOutput where FLAG = '888888' and A11 =7 group by a13 order by aa
select COUNT(*) as aa, a22 from TestOutput where FLAG = '888888' and A11 =7 group by a19 order by aa
select COUNT(*) as aa, a28 from TestOutput where FLAG = '888888' and A11 =7 group by a25 order by aa

select COUNT(*) as aa, a30 from TestOutput where FLAG = '888888' and A11 =3 group by a30 order by aa
/*26*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput 
where FLAG = '888888' and A11 =9 group by a13 having count(*) <2) as bb
/*25*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput 
where FLAG = '888888' and A11 =9 group by a19 having count(*) <2) as bb
/*27*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput 
where FLAG = '888888' and A11 =9 group by a25 having count(*) <2) as bb


/*26*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput 
where FLAG = '888888' and A11 =7 group by a16 having count(*) <2) as bb
/*25*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput 
where FLAG = '888888' and A11 =7 group by a22 having count(*) <2) as bb
/*27*/select sum(bb.aa) from (select COUNT(*) as aa from TestOutput 
where FLAG = '888888' and A11 =7 group by a28 having count(*) <2) as bb

/*25-27*/select * from TestOutput where FLAG = '888888' and A11 =5 order by a10 desc
/*26*/select * from TestOutput where FLAG = 888888 and A11 = 6 and A16 like '52221%'
/*25*/select * from TestOutput where FLAG = 888888 and A11 = 6 and A22 like '51121%'
/*27*/select * from TestOutput where FLAG = 888888 and A11 = 6 and A28 like '22343%'

/*25-27*/select * from TestOutput where FLAG = '888888' and A11 =6 order by a10 desc
/*26*/select * from TestOutput where FLAG = 888888 and A11 = 7 and A16 like '352221%'
/*25*/select * from TestOutput where FLAG = 888888 and A11 = 7 and A22 like '351121%'
/*27*/select * from TestOutput where FLAG = 888888 and A11 = 7 and A28 like '422343%'


/*25-27*/select * from TestOutput where FLAG = '888888' and A11 =19 order by a10 desc
/*26*/select * from TestOutput where FLAG = 888888 and A11 = 19 and A16 like '4222533324233352221%'
/*25*/select * from TestOutput where FLAG = 888888 and A11 = 19 and A22 like '3222322313222351121%'
/*27*/select * from TestOutput where FLAG = 888888 and A11 = 19 and A28 like '3315144231242422343%'

/*25-27*/select * from TestOutput where FLAG = '888888' and A11 =8 order by a10 desc
/*26*/select * from TestOutput where FLAG = 888888 and A11 = 9 and A13 like '02020110%'
/*25*/select * from TestOutput where FLAG = 888888 and A11 = 9 and A19 like '12220212%'
/*27*/select * from TestOutput where FLAG = 888888 and A11 = 9 and A25 like '00012020%'

select * from TestOutput where FLAG = 888888 and A11 = 3 and A16 like '44%' and A22 like '32%' and A28 like '23%'

select * from TestOutput where FLAG = 999999 order by a0 desc
select A12, a13, count(*) as aa from TestOutput where FLAG = 999999 group by A12,a13 order by aa 
select A12, count(*) as aa from TestOutput where FLAG = 999999 group by A12 order by aa
select a13, count(*) as aa from TestOutput where FLAG = 999999 group by a13 order by aa


select A14, a15, count(*) as aa from TestOutput where FLAG = 999999 group by A14,a15 order by aa 

select * from TestOutput where FLAG = 999999 and A15 like '%' +A14 + '%'
select * from TestOutput where FLAG = 999999 and A17 like '%' +A16 + '%'
select * from TestOutput where FLAG = 999999 and A19 like '%' +A18 + '%'


select * from TestOutput where FLAG = 999999 and A19 like '%' +A18 + '%' and A17 like '%' +A16 + '%' and A15 like '%' +A14 + '%'

select * from TestOutput where FLAG = 999999 and A19 like '%' +A18 + '%' and A17 like '%' +A16 + '%' and A15 not like '%' +A14 + '%'

select * from TestOutput where FLAG = 999999 and A19 like '%' +A18 + '%' and A17 not like '%' +A16 + '%' and A15 like '%' +A14 + '%'

select * from TestOutput where FLAG = 999999 and A19 not like '%' +A18 + '%' and A17 like '%' +A16 + '%' and A15 like '%' +A14 + '%'

select * from TestOutput where FLAG = 999999 and A19 like '%' +A18 + '%' and A17 not like '%' +A16 + '%' and A15 not like '%' +A14 + '%'

select * from TestOutput where FLAG = 999999 and A19 not like '%' +A18 + '%' and A17 not like '%' +A16 + '%' and A15 like '%' +A14 + '%'

select * from TestOutput where FLAG = 999999 and A19 not like '%' +A18 + '%' and A17 like '%' +A16 + '%' and A15 not like '%' +A14 + '%'

update TestOutput set A1 = cast(a14 as decimal(9,1))+cast(a16 as decimal(9,1))+cast(a18 as decimal(9,1)) where FLAG = 999999

/*prime+two+*/select cast(a14 as decimal(9,1))+cast(a16 as decimal(9,1))+cast(a18 as decimal(9,1)), count(*) as aa from TestOutput where FLAG = 999999 group by cast(a14 as decimal(9,1))+cast(a16 as decimal(9,1))+cast(a18 as decimal(9,1)) order by aa 


select * from TestOutput where FLAG = 000000  and A12 not like '%01%' and A12 not like '%02%'


/*UPSum30*/select a0 /10, COUNT(*) as aa from TestOutput where FLAG = 000000 group by a0 /10 order by aa


select a12, COUNT(*) as aa from TestOutput where FLAG = 000000 group by a12 order by aa

select COUNT(*) from TestOutput where FLAG = 000000 and A12 not like '%16%'

