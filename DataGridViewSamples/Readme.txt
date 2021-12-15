DataGridView常见用法和FAQ汇总

约定：
1、DataGridView 缩写为 DGV
2、配置文件中DefaultConnString节点的值为数据库Northwind的连接字符串

概要：
一、基本数据绑定操作
　　绑定、新增、修改、删除
二、外观操作
    单元格外观、排序
三、列操作
    各种内置列以及自定义列
四、范型应用
五、最佳实践


重构：
	现在有很多重复方法，类等内容散落在各窗体中，需要进行抽象整理；
	
	
Tricks:
	点击右键，选择Edit Columns以编辑列；	
	
	
Schedule:
    通过继承，实现对滚动条的控制；
    
2006/11/25
操作数据->数据输入和验证；（OK）
如果行出现错误，显示提示信息，如果用户按Escape键，如何取消提示符号（OK，在RowValidated事件中）；
新增、修改、删除数据（OK）；
更新数据时，使用两种方法，一是用DataAdapter的Update方法，二是使用自定义的方式操作数据库(OK)；

第一章翻译(OK)；

2006/11/26
DataView之外的数据源如Array, ArrayList, Hashtable, Business Ojbect的绑定；
BindingSource组件的理解；（DGV与数据源的桥梁，更改通知机制）
范型List的使用；
大数据量的分页；
如何处理空日期值或NULL值；

使用DataAdapter的Update方法更新数据库，避免大量的SQL拼接(OK)；
但同时感觉又暴露了很多数据接口，如数据库连接、SqlCommand、SqlDataAdapter等，如何封装？使用自定义Form类？

第二章翻译(OK)；

2006/11/27
SqlDataAdapter如何处理 自动生成列（在插入新行时）

2006/11/28
第三章翻译(OK);

2006/11/29
第四章翻译(Not very good);

2006/12/03
Virtual Mode;(OK)
FAQ Section;(Almost)
Refactor;
DateTimePicker Column;
CheckBox Column;(OK)
MS Samples;

2006/12/04
Publish it;(can't ->wen)

未完成的部分：
第五章、第六章翻译；
更多数据源的绑定；
分页功能；IDataPageRetriever；
性能问题；