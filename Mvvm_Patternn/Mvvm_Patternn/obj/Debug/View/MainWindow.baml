   M S B A M L   `   `   `  ����H  DMvvm_Patternn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mvvm_PatternnMvvm_Patternn  5   	   A%clr-namespace:Mvvm_Patternn.ViewModelMvvm_Patternn.ViewModel  5   	       Mvvm_Patternn.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Mvvm_Patternn     5   	   8local1%clr-namespace:Mvvm_Patternn.ViewModel     5   	   a ]DevExpress.Xpf.Grid.v14.2, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v14.2.Core, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	     � Title$  
MainWindow��5
   	   $	��350��6   $	��300��6)    � 	Resources 5      $  DevExpress.Xpf.Grid.GridColumn �� 
TargetType$  DevExpress.Xpf.Grid.BaseColumn �� Property �� Value%   Mvvm_Patternn.Product_ViewModel   
product_VM/   )Mvvm_Patternn.ViewModel.Company_ViewModel  
company_VM��%�   '        &	  r     &	 �     �� 5   
   "  6   .�5      �� ( �@  HorizontalHeaderContentAlignment$ Center=�6A   6R   5        5   
   6"     5   
   6#   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5       $
��auto �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��* �6#   .+�5&      �� Id5'      �� 5(      $��1��6   $��0��5)      Name5*      �� 5,      -   5         ��Name$ txtId��5/      $��0��5,      $��1��5-      $��3��5.       �� 
IsReadOnly . ��50      �� 	 �� ElementName$	 grdcProducts��
 �� Path$ 
 View.FocusedRowData.Row.Id�.��51   (   52      �� 53      -   5        $ txtName��56      $��1��53      $��1��54      $��3��55      ��57      �� $	 grdcProducts��$"
 View.FocusedRowData.Row.Name� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   58      �� 5:      $��2��6   $��1��5;      $��Update��5<      $��75��5=      $
��Left=�5>      ��5?      �� *UpdateCommand+ �� Source# [  ��5@      �� *SelectedProduct+# [  5A      �� 5B      $��2��6   $��2��5C      $��75��5D      $	��Add��5G      ��5E      �� *
AddCommand+# [  ��5F      �� *SelectedProduct+# [  5H      �� 5I      $��2��6   $��3��5J      $
��Add2��5K      $��75��5L      ��5M      �� *
AddCommand+# [ ��5N      �� *SelectedCompany+# [ 5O      5P      %  DevExpress.Xpf.Grid.GridControl  5Q   
   -   5          Name$ grdcCompany��5Q      $��1��5R      )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5S      �� *	Companies+# [    View 5W      #  DevExpress.Xpf.Grid.TableView  5X      -   5          Name$ grdvCompany��5X          	AutoWidth . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &	   DevExpress.Xpf.Grid.DataViewBase 	  
FocusedRow 5Z       �� $
 SelectedCompany�$ OneWayToSource=�# [ 5\         Columns 5^        5_      $
  DevExpress.Xpf.Grid.ColumnBase 
  Binding 6!   �� $
 Id�   Header. 6=   Id6A     5`       6!   �� $

 Name�. 6?   Name6E   5b        5c   
   -   5        $ grdcProducts��5c      $��2��5d       5e      �� $
 Products�# [   5f        5g      -   5        $ grdvProducts��5j        .   .  5i   $   �� $
 SelectedProduct�$ OneWayToSource=�# [  5k       5m        5n       6!   �� *Id+. 68   Id6<     5o       6!   �� *Name+. 6:   Name6@   5q      5s      5t      