--
SELECT * FROM TblStudent WHERE tSName like '%[%]%';

SELECT top 100 * FROM TblStudent 
where tSName like '%\\%%' 
order by tSId desc;

CREATE INDEX de_se_re ON DicRegion (FullName,MapBarName,abbr);

set statistics io on

select * from DicRegion where FullName='������'

select * from DicRegion where FullName='������' AND abbr='����'

select * from DicRegion where FullName='������' AND MapBarName='������'

select * from DicRegion where abbr='����' AND MapBarName='������'

select * from DicRegion where abbr='����'

select * from DicRegion where MapBarName='������'

select * from DicRegion where AreaCode=010

set statistics io off


select db_name(database_id) as N'���ݿ�����',
       object_name(a.object_id) as N'����',
       b.name N'��������',
       user_seeks N'�û��������Ҵ���',
       user_scans N'�û�����ɨ�����',
       last_user_seek N'������ʱ��',
       last_user_scan N'���ɨ��ʱ��',
       rows as N'���е�����'
from sys.dm_db_index_usage_stats a join 
     sys.indexes b
     on a.index_id = b.index_id
     and a.object_id = b.object_id
     join sysindexes c
     on c.id = b.object_id
where database_id=db_id('���ݿ���')   --ָ�����ݿ�
     and object_name(a.object_id) not like 'sys%'
     and object_name(a.object_id) like '����'  --ָ��������
     and b.name like '������' --ָ���������� ������ʹ�� sp_help '��ı���' �鿴��Ľṹ�����е�������Ϣ
order by user_seeks,user_scans,object_name(a.object_id)
 
select 
tscoreId,
tsid,
tenglish,
�ȼ�=
case
	when tEnglish >= 95 then '��'
	when tEnglish >= 8 then '��'
	when tEnglish >= 70 then '��'
	else '��'
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
	����Ա,
	�����ܽ��=sum(��������*���ۼ۸�),
	�ƺ�=
		case
			when sum(��������*���ۼ۸�)>6000 then '����'
			when SUM(��������*���ۼ۸�)>5000 then '����'
			when SUM(��������*���ۼ۸�)>4500 then 'ͭ��'
			else '��ͨ'
		end
from MyOrders
group by ����Ա

select * from TeamScore;

select 
	teamName,
	ʤ=
		sum(case gameResult
			when 'ʤ' then 1
			else 0
		end),
	��=
		sum(case gameResult
			when '��' then 1
			else 0
		end)
from TeamScore
group by teamName;

select 
	teamName,
	ʤ=
		count(case gameResult
			when 'ʤ' then 'ʤ'
		end),
	��=
		count(case gameResult
			when '��' then '��'
		end)
from TeamScore
group by teamName

select 
	teamName,
	��һ�����÷�=
		sum(case seasonName
			when '��1����' then Score
		end),
	�ڶ������÷�=
		sum(case seasonName
			when '��2����' then Score
		end),
	���������÷�=
		sum(case seasonName
			when '��3����' then Score
		end)
from NBAScore
group by teamName

select * from StudentScore

select 
	studentId,
	����=
		SUM(case courseName
				when '����' then score
				else null
			end),
	��ѧ=
		SUM(case courseName
				when '��ѧ' then score
				else null
			end),
	Ӣ��=
		SUM(case courseName
				when 'Ӣ��' then score
				else null
			end)
from StudentScore
group by studentId

select * from myOrders;

select 
	��Ʒ���,
	��Ʒ����,
	����=
		sum(case ����Ա 
			when '����' then ��������
			else null
		end),
		
	����=
		sum(case ����Ա 
			when '����' then ��������
			else null
		end),
	����=
		sum(case ����Ա 
			when '����' then ��������
			else null
		end),
	����=
		sum(case ����Ա 
			when '����' then ��������
			else null
		end),
	����=
		sum(case ����Ա 
			when '����' then ��������
			else null
		end)
from MyOrders
group by ��Ʒ���,��Ʒ����

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

use masterif exists(select * from sysdatabases where [name] = 'PhoneNumManager')	drop database PhoneNumManagergocreate database PhoneNumManagergouse PhoneNumManagergocreate table PhoneType(	ptId int identity(1,1) primary key,	ptName nvarchar(50) ) gocreate table PhoneNum(	pId int identity(1,1) primary key,	pTypeId int not null,	pName nvarchar(50),	pCellPhone varchar(50),	pHomePhone varchar(50))goalter table PhoneNumadd constraint FK_PhoneNum foreign key (pTypeId) references PhoneType(ptId)gocreate view view_Phoneas 	select pId, pTypeId, pName, pCellPhone, pHomePhone,ptName from dbo.PhoneNum	inner join dbo.PhoneType on pTypeId = ptIdgoinsert into PhoneType values('����')insert into PhoneType values('ͬ��')insert into PhoneType values('ͬѧ')insert into PhoneType values('����')insert into PhoneNum values(1,'����','13000000000','7000000')insert into PhoneNum values(1,'����','13000000001','7000001')insert into PhoneNum values(1,'�ŷ�','13000000002','7000002')insert into PhoneNum values(2,'�ܲ�','13300000003','8000003')insert into PhoneNum values(2,'����','13300000004','8000004')insert into PhoneNum values(3,'��Ȩ','13400000003','9000003')insert into PhoneNum values(3,'С��','13400000004','9000004')select * from phoneTypeselect * from phonenumselect 	pn.pname,	pn.pCellphone,	pt.ptnamefrom phonetype  ptinner join phonenum pn on pt.ptId = pn.pTypeIdselect pn.pid,pn.pTypeId,pn.pname,pn.pCellphone,pt.ptname from phonetype pt inner join phonenum pn on pt.ptId = pn.pTypeIdselect ptid,ptname from PhoneTypeselect * from dicRegionselect * from mystudentselect * from (select row_number() over(order by Id asc) num,* from DicRegion) t where t.num between 1 and 6select Id,Grade,ParentId,Description from (select row_number() over(order by Id asc) num,* from DicRegion) t where t.num between 1 and 7create proc GetSum @a int,@b intasbegin	print @a + @benddrop proc GetSumuse Itcast2014create proc usp_getSum @a int,@b intasbegin	print @a+@bendexec usp_getSum @a=10,@b=20select * from tblscorecreate proc usp_GetTblScore @min int,@max intasbegin	select * from tblscore where tenglish between @min and @maxendexec usp_gettblscore @min=60,@max=90--��ҳ�洢����--select * from mystudent--select * from (select row_number() over(order by fid asc) num,* from mystudent) t  where t.num between 1 and 5--ҳ���ÿҳ��ʾ����,����ܼ�¼������ҳ��alter proc usp_Paging_MyStudent @pageIndex int,@pageSize int,@totalRecordNum int output,@totalPageNum int outputasbegin	--��ѯ���	select 		* 	from (select row_number() over(order by fid asc) num,* from mystudent) t 	where t.num 	between (@pageindex-1)*@pagesize+1 and @pageindex*@pagesize	--��ȡ�ܼ�¼��	set @totalrecordnum = (select count(*) from mystudent)	--��ȡ��ҳ��	set @totalpagenum = ceiling(@totalrecordnum*1.0/@pagesize)enddeclare @totalrecordnum intdeclare @totalpagenum intexec usp_paging_mystudent @pageindex=1,@pagesize=5,@totalrecordnum=@totalrecordnum output,@totalPageNum=@totalPageNum outputprint @totalrecordnumprint @totalPageNum--�洢���̷�װ��������--select * from bankcreate proc usp_bank@from char(4), --ת���˻�@to char(4),	--�����˻�@balance money, --Ǯ��@status int outputasbegin	--�ж�Ǯ���Ƿ��㹻ת��	declare @money money	select @money=balance from bank where cid=@from	--set @money = (select balance from bank where cid=@from)	if @money-@balance>=10	begin		begin transaction --��������		declare @sum int		set @sum=0		update bank set balance=balance-@balance where cid=@from		set @sum=@sum+@@error		update bank set balance=balance+@balance where cid=@to		set @sum=@sum+@@error		if @sum<>0		begin			set @status=2			rollback		end		else		begin			set @status=1			commit		end	end	else	begin		set @status=3	endend