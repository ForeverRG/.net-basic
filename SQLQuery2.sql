--
SELECT * FROM TblStudent WHERE tSName like '%[%]%';

SELECT top 100 * FROM TblStudent 
where tSName like '%\\%%' 
order by tSId desc;

CREATE INDEX de_se_re ON DicRegion (FullName,MapBarName,abbr);

set statistics io on

select * from DicRegion where FullName='北京市'

select * from DicRegion where FullName='北京市' AND abbr='北京'

select * from DicRegion where FullName='北京市' AND MapBarName='北京市'

select * from DicRegion where abbr='北京' AND MapBarName='北京市'

select * from DicRegion where abbr='北京'

select * from DicRegion where MapBarName='北京市'

select * from DicRegion where AreaCode=010

set statistics io off


select db_name(database_id) as N'数据库名称',
       object_name(a.object_id) as N'表名',
       b.name N'索引名称',
       user_seeks N'用户索引查找次数',
       user_scans N'用户索引扫描次数',
       last_user_seek N'最后查找时间',
       last_user_scan N'最后扫描时间',
       rows as N'表中的行数'
from sys.dm_db_index_usage_stats a join 
     sys.indexes b
     on a.index_id = b.index_id
     and a.object_id = b.object_id
     join sysindexes c
     on c.id = b.object_id
where database_id=db_id('数据库名')   --指定数据库
     and object_name(a.object_id) not like 'sys%'
     and object_name(a.object_id) like '表名'  --指定索引表
     and b.name like '索引名' --指定索引名称 可以先使用 sp_help '你的表名' 查看表的结构和所有的索引信息
order by user_seeks,user_scans,object_name(a.object_id)
 
select 
tscoreId,
tsid,
tenglish,
等级=
case
	when tEnglish >= 95 then '优'
	when tEnglish >= 8 then '良'
	when tEnglish >= 70 then '中'
	else '差'
end
from TblScore

create table TestA
(
	A int,
	B int,
	C int
)

insert into TestA values (10,20,30)
insert into TestA values (20,30,10)
insert into TestA values (30,10,20)
insert into TestA values (10,20,30)

select * from TestA

select 
	x=
	case 
		when A>B then A
		else B
	end,
	y=
	case
		when B>C then B
		else C
	end
from TestA

select * from MyOrders;

select 
	销售员,
	销售总金额=sum(销售数量*销售价格),
	称号=
		case
			when sum(销售数量*销售价格)>6000 then '金牌'
			when SUM(销售数量*销售价格)>5000 then '银牌'
			when SUM(销售数量*销售价格)>4500 then '铜牌'
			else '普通'
		end
from MyOrders
group by 销售员

select * from TeamScore;

select 
	teamName,
	胜=
		sum(case gameResult
			when '胜' then 1
			else 0
		end),
	负=
		sum(case gameResult
			when '负' then 1
			else 0
		end)
from TeamScore
group by teamName;

select 
	teamName,
	胜=
		count(case gameResult
			when '胜' then '胜'
		end),
	负=
		count(case gameResult
			when '负' then '负'
		end)
from TeamScore
group by teamName

select 
	teamName,
	第一赛季得分=
		sum(case seasonName
			when '第1赛季' then Score
		end),
	第二赛季得分=
		sum(case seasonName
			when '第2赛季' then Score
		end),
	第三赛季得分=
		sum(case seasonName
			when '第3赛季' then Score
		end)
from NBAScore
group by teamName

select * from StudentScore

select 
	studentId,
	语文=
		SUM(case courseName
				when '语文' then score
				else null
			end),
	数学=
		SUM(case courseName
				when '数学' then score
				else null
			end),
	英语=
		SUM(case courseName
				when '英语' then score
				else null
			end)
from StudentScore
group by studentId

select * from myOrders;

select 
	商品编号,
	商品名称,
	王大=
		sum(case 销售员 
			when '王大' then 销售数量
			else null
		end),
		
	刘七=
		sum(case 销售员 
			when '刘七' then 销售数量
			else null
		end),
	张三=
		sum(case 销售员 
			when '张三' then 销售数量
			else null
		end),
	李四=
		sum(case 销售员 
			when '李四' then 销售数量
			else null
		end),
	赵五=
		sum(case 销售员 
			when '赵五' then 销售数量
			else null
		end)
from MyOrders
group by 商品编号,商品名称

select * from TblStudent

select * from tblclass

select 
	tbls.tSName,
	tbls.tSAge,
	tblc.tClassName
from TblStudent tbls
inner join TblClass tblc
on tbls.tSClassId=tblc.tClassId

select tsname,tsage from TblStudent

select * from TblScore;

select * from TblStudent

select 
	tbs.tsname,
	tbs.tsage,
	tblc.tenglish,
	tblc.tmath
from TblStudent tbs 
inner join TblScore tblc
on tbs.tSId = tblc.tSId

select 
	tbs.tsname,
	tbs.tsage,
	tblc.tenglish,
	tblc.tmath
from TblStudent tbs 
left join TblScore tblc
on tbs.tSId = tblc.tSId

select 
	tbs.tsname,
	tbs.tsage,
	tblc.tenglish,
	tblc.tmath
from TblStudent tbs 
right join TblScore tblc
on tbs.tSId = tblc.tSId

select 
	tsid,
	tsname,
	tsage
from TblStudent 
where tSId 
not in (
	select 
		tSId
	from TblScore
)

use Itcast2014

select * from bank

select * from Category

select * from ContentInfo

insert into Category values ("@tName",@tParentId,"@tNote")

delete from Category where tParentId=0

sp_columns ContentInfo

select * from 
(select ROW_NUMBER() over(order by tId asc) num, * from Category) s
where s.num between 6 and 10 order by tId asc

select * from TblClass

select * from phone

use masterif exists(select * from sysdatabases where [name] = 'PhoneNumManager')	drop database PhoneNumManagergocreate database PhoneNumManagergouse PhoneNumManagergocreate table PhoneType(	ptId int identity(1,1) primary key,	ptName nvarchar(50) ) gocreate table PhoneNum(	pId int identity(1,1) primary key,	pTypeId int not null,	pName nvarchar(50),	pCellPhone varchar(50),	pHomePhone varchar(50))goalter table PhoneNumadd constraint FK_PhoneNum foreign key (pTypeId) references PhoneType(ptId)gocreate view view_Phoneas 	select pId, pTypeId, pName, pCellPhone, pHomePhone,ptName from dbo.PhoneNum	inner join dbo.PhoneType on pTypeId = ptIdgoinsert into PhoneType values('朋友')insert into PhoneType values('同事')insert into PhoneType values('同学')insert into PhoneType values('家人')insert into PhoneNum values(1,'刘备','13000000000','7000000')insert into PhoneNum values(1,'关羽','13000000001','7000001')insert into PhoneNum values(1,'张飞','13000000002','7000002')insert into PhoneNum values(2,'曹操','13300000003','8000003')insert into PhoneNum values(2,'大乔','13300000004','8000004')insert into PhoneNum values(3,'孙权','13400000003','9000003')insert into PhoneNum values(3,'小乔','13400000004','9000004')select * from phoneTypeselect * from phonenumselect 	pn.pname,	pn.pCellphone,	pt.ptnamefrom phonetype  ptinner join phonenum pn on pt.ptId = pn.pTypeIdselect pn.pid,pn.pTypeId,pn.pname,pn.pCellphone,pt.ptname from phonetype pt inner join phonenum pn on pt.ptId = pn.pTypeIdselect ptid,ptname from PhoneTypeselect * from dicRegionselect * from mystudentselect * from (select row_number() over(order by Id asc) num,* from DicRegion) t where t.num between 1 and 6select Id,Grade,ParentId,Description from (select row_number() over(order by Id asc) num,* from DicRegion) t where t.num between 1 and 7create proc GetSum @a int,@b intasbegin	print @a + @benddrop proc GetSumuse Itcast2014create proc usp_getSum @a int,@b intasbegin	print @a+@bendexec usp_getSum @a=10,@b=20select * from tblscorecreate proc usp_GetTblScore @min int,@max intasbegin	select * from tblscore where tenglish between @min and @maxendexec usp_gettblscore @min=60,@max=90--分页存储过程--select * from mystudent--select * from (select row_number() over(order by fid asc) num,* from mystudent) t  where t.num between 1 and 5--页码和每页显示条数,输出总记录数和总页数alter proc usp_Paging_MyStudent @pageIndex int,@pageSize int,@totalRecordNum int output,@totalPageNum int outputasbegin	--查询结果	select 		* 	from (select row_number() over(order by fid asc) num,* from mystudent) t 	where t.num 	between (@pageindex-1)*@pagesize+1 and @pageindex*@pagesize	--获取总记录数	set @totalrecordnum = (select count(*) from mystudent)	--获取总页数	set @totalpagenum = ceiling(@totalrecordnum*1.0/@pagesize)enddeclare @totalrecordnum intdeclare @totalpagenum intexec usp_paging_mystudent @pageindex=1,@pagesize=5,@totalrecordnum=@totalrecordnum output,@totalPageNum=@totalPageNum outputprint @totalrecordnumprint @totalPageNum--存储过程封装银行事务--select * from bankcreate proc usp_bank@from char(4), --转账账户@to char(4),	--收账账户@balance money, --钱数@status int outputasbegin	--判断钱数是否足够转账	declare @money money	select @money=balance from bank where cid=@from	--set @money = (select balance from bank where cid=@from)	if @money-@balance>=10	begin		begin transaction --开启事务		declare @sum int		set @sum=0		update bank set balance=balance-@balance where cid=@from		set @sum=@sum+@@error		update bank set balance=balance+@balance where cid=@to		set @sum=@sum+@@error		if @sum<>0		begin			set @status=2			rollback		end		else		begin			set @status=1			commit		end	end	else	begin		set @status=3	endend