/*(localdb)\MSSQLLocalDB*/
create table imgdata(id int identity primary key,filename varchar(100),password varchar(100),destpath varchar(200))
select * from imgdata


create procedure imgins
@fn varchar(100),
@pw varchar(100),
@dp varchar(200)
as
begin
insert into imgdata(filename,password,destpath) values(@fn,@pw,@dp)
end

create procedure imgsho
as
begin
select filename from imgdata
end

create procedure imgdel
@fn varchar(100)
as
begin
delete from imgdata where filename=@fn
end


create procedure imgfp
as
begin
select filename,password from imgdata
end

exec imgins 'heloo.txt','123qwe','C\dd:dsdc\'

exec imgfp

exec imgdel 'heloo.txt'