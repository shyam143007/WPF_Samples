   M S B A M L   `   `   `  ����B  >Samples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SamplesSamples  5   	       Samples.Triggers_Sample   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Samples     5   	     � Title$  Triggers_Sample��5   	   $	��300��6!   $	��300��6.    � 	Resources 5	         propertyTrigger �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  dataTrigger �� Binding	 �� Path
 �� Value  eventTrigger :� RoutedEvent g� Duration �� TargetProperty	 W� To��%�  &	        &	 �     &	 �    �� 5
   
   " ��6(   .�5      ��  � ��
 ��  �6:    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 �  ��6A   �� 5       � ��$ 	underline{�68   6L   5      5      �� 5   
   " ��6$   .�5      ��  � ��
 ��  �6:    5      �� 5       6   �� $	 StyleChanger�
 16E   .a�5      ��  � ��
 �  ��6A   �� 5       � ��$ 	underline{�68   6L   5      5      �� 5   
   " ��6%    5      :� 5       $ 
MouseEnter��6   [�5!      �� 5"      .��5#      �� .��5$   "   W� $ 0:0:2D�62   $ FontSize�5%   2   $ 35X�5&   2   5'   #   5(      5)      5+      :� 5,      $ 
MouseLeave��6   .[�5-      �� .��5.      �� .��5/      W� $ 0:0:2D�6.   $ FontSize�50   .   $ 15X�51   .   52      53      54      55      57      58      .��59      � .+�5:   
   �� $��Hello, style world��6   $��15(�5;      $��Center=�5<      $��Center=�5=      #��[ 5>      z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C       �� Angle$ -359.535Q�6&   T� 5D      5E      5G      �� 5H   
   -   5         ��Name$ btnChangeStyle��5H      $��Center=�5I      $��Bottom=�5J      $��50��5K      $��35��5L      $��Click��5M      ��5O      �� 5P      " ��6    5Q      P� 5R       � �� . . �5S      ��  � ��
 �  ��6;   5T      5V      5X      5Y      5Z      