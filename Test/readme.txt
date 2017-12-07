免责声明：共享软件，查找最近修改过的文件，另存为文本文件，数据丢失，作者不负任何责任。
程序源码在: https://github.com/heguo/FilterFiles.git
WinServer2003上测试通过，需要 .net framework 2.0 支持（通常都有）

cmd 执行下面这行指令，开始备份最近1天修改过的文件, 显示出来
FilterFiles -run:true -from:D:\code\FilterFiles -match:*.zip -to:D:\test -day:1 -ip:obj -if:123efg -output:dir_{from}_{to}_{todir}_y>> d:\output.bat

格式：
FilterFiles.exe -run:是否自动启动 -from:需备份的文件夹 -match:*.* -to:目标文件夹 -day:最近修改天数 -ip:忽略的文件夹名称1;名称2 -if:忽略的文件1;文件2 -output:dir_{from}>>output.bat

参数说明：
run   自动执行备份，备份完成，自动关闭
from 待备份的文件夹
math 查找的文件类型，或文件名匹配规则
to      备份至目标文件夹
day   最近几天内修改的文件，0表示今天凌晨零时起计，1表示昨天凌晨零时起计
ip      备份过程中忽略掉的文件夹名称
if       备份过程中忽略掉的文件名， 如: abc;.log
output 输出的格式，下划线(_)替换为空格


有疑问联系作者: shuozi@sohu.com