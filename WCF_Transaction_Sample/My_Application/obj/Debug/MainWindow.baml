   M S B A M L   `   `   `  ����I  EMy_Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:My_ApplicationMy_Application  5   	       My_Application.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:My_Application     5   	   f bDevExpress.Xpf.Grid.v14.2.Core, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v14.2, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   -   5          � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)    � 	Resources 5
      $  DevExpress.Xpf.Grid.GridColumn �� 
TargetType$  DevExpress.Xpf.Grid.BaseColumn �� Property �� Value   	AddPerson��%�   '        &	  m     �� 5   
   "  6   .�5      �� ( �@  HorizontalHeaderContentAlignment$ Center=�6A   5      �� 5   
   6   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6>    J� InputBindings 5      �� 5   
    �� Command# [  6   	 �� 	Modifiers$	 Shiftf�6:   

 �� Key$
 N��6L   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   %  DevExpress.Xpf.Grid.GridControl  )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6   ��  �� Path$ Persons�   View 5      #  DevExpress.Xpf.Grid.TableView  5         	AutoWidth . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  61      Columns 5        5       -   5          Name$
 gcId��5    !      Headera ]DevExpress.Xpf.Core.v14.2, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a)  #DevExpress.Xpf.Core.ObjectConverter$ Id 6/   $	  DevExpress.Xpf.Grid.ColumnBase 	  Binding 6;   �� $ Id�  5!      -   5        $ gcName��5!   !   $
 Name 61    6?   �� $
 Name�5#      � 5(   
   $��1��6    � ColumnDefinitions 5)      �� 5*      �� 5+      �� 5,       5.      �� 5/      �� 50      �� 51      .+�53      �� $��0��6   $��1��6$   $
��Name��61   $��Right=�6@   $��Center=�6\   $��0,0,20,0q�6w   �� 54      -   5         ��Name$ txtName��54   3   $��1��6   $��1��6&   $��Center=�6D    �� 	MaxLength$ 50��6_   �� 55      $��1��6   $��2��6%   $	��Add��62   $��Center=�6@   $��Center=�6[   $��50��6x   #��[  6�   56      57      58      