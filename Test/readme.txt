���������������������������޸Ĺ����ļ������Ϊ�ı��ļ������ݶ�ʧ�����߲����κ����Ρ�
����Դ����: https://github.com/heguo/FilterFiles.git
WinServer2003�ϲ���ͨ������Ҫ .net framework 2.0 ֧�֣�ͨ�����У�

cmd ִ����������ָ���ʼ�������1���޸Ĺ����ļ�, ��ʾ����
FilterFiles -run:true -from:D:\code\FilterFiles -match:*.zip -to:D:\test -day:1 -ip:obj -if:123efg -output:dir_{from}_{to}_{todir}_y>> d:\output.bat

��ʽ��
FilterFiles.exe -run:�Ƿ��Զ����� -from:�豸�ݵ��ļ��� -match:*.* -to:Ŀ���ļ��� -day:����޸����� -ip:���Ե��ļ�������1;����2 -if:���Ե��ļ�1;�ļ�2 -output:dir_{from}>>output.bat

����˵����
run   �Զ�ִ�б��ݣ�������ɣ��Զ��ر�
from �����ݵ��ļ���
math ���ҵ��ļ����ͣ����ļ���ƥ�����
to      ������Ŀ���ļ���
day   ����������޸ĵ��ļ���0��ʾ�����賿��ʱ��ƣ�1��ʾ�����賿��ʱ���
ip      ���ݹ����к��Ե����ļ�������
if       ���ݹ����к��Ե����ļ����� ��: abc;.log
output ����ĸ�ʽ���»���(_)�滻Ϊ�ո�


��������ϵ����: shuozi@sohu.com