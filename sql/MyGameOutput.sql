select COUNT(*), A0  from TestOutput where FLAG = 10 group by A0 
select COUNT(*), A1  from TestOutput where FLAG = 10 group by A1 
select COUNT(*), A2  from TestOutput where FLAG = 10 group by A2 
select COUNT(*), A3  from TestOutput where FLAG = 10 group by A3 
select * from TestOutput where FLAG = 10
select COUNT(*), A0,A1  from TestOutput where FLAG = 0 group by A0,A1 