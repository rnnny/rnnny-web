select * from out

select field1, field2, [$N-field1], [$N-field2], [$N-field1] - field1 as a1, [$N-field2] - field2 as a2 from out

select [$N-field1] - field1 as a1, COUNT(*) as aa from out group by [$N-field1] - field1 order by aa desc

select [$N-field2] - field2 as a2, COUNT(*) as aa from out group by [$N-field2] - field2 order by aa desc 

select * from 输出

select 列21 , 列1 from 输出 where abs(列21 - 列1) <=19

select [$N-field2] - field2 as a2,[$N-field2] , field2 from out1 where abs([$N-field2] - field2) <=2

select [$N-field2] - field2 as a2,[$N-field2] , field2 from out2 where abs([$N-field2] - field2) <=1