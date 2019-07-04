declare @sql nvarchar(2000)
select @sql = 'BACKUP DATABASE [HIS_PR] TO DISK = ''E:\Databackup\HIS_PR_' +convert(varchar, getdate(), 110)
+ '.bak'' WITH RETAINDAYS = 30, NOFORMAT, NOINIT, NAME = N''HIS_PR-Daily Database Backup'', SKIP, NOREWIND, NOUNLOAD, STATS = 10'
execute sp_executesql @sql
GO