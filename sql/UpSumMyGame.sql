
--delete from TestOutput
select * from TestOutput where FLAG = 000000  and A12 not like '%01%' and A12 not like '%02%'


/*UPSum30*/select a0 /10, COUNT(*) as aa from TestOutput where FLAG = 000000 group by a0 /10 order by aa


select a12, COUNT(*) as aa from TestOutput where FLAG = 000000 group by a12 order by aa

select COUNT(*) from TestOutput where FLAG = 000000 and A12 not like '%16%'