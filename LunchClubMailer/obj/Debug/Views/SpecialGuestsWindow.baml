   M S B A M L   `   `   `  ����  LunchClubMailer)    #LunchClubMailer.SpecialGuestsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � Title$  Special Guests��5      $	��270��5      $	��600��6   
�����p�$	��270��6>   $	��900��6N   $	��600��6^    � 	Resources 5	       �� 
TargetType �� Property �� Value��%T   '��       �� 5
      " ��6   .�5      ��  � ��$
 Bold"�6%   5      5      .��5      �  � RowDefinitions 5      �� 5      $��25 �6   �� 5      $��1* �6   �� 5      $��60 �6    � ColumnDefinitions 5      �� 5      $��1* �6   �� 5      $��1* �6   .+�5      �� $��Guest Names��6   $��0��6"   &   System.Windows.Controls.DataGrid  5      $��1��6   $	��5,0q�6      AutoGenerateColumns .  ��. $
��Auto=�5   4   $
��Auto=�6f   ��5   )   �� *	guestList+ �� Mode$ OneWay=�	 �� SelectedItem	 6X   �� *selectedGuest+
   Columns
 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5   
   ,  &System.Windows.Controls.DataGridColumn   Header$ 
Attending?��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *isAttending+$ TwoWay=�6b   0  *System.Windows.Controls.DataGridTextColumn  5   
      
IsReadOnly . $ 
Guest Name��6/   $
 100* 6\    6C   �� *name+6\   5       A� 5!       A� Rows$ 1��6   $��2��6   .+�5"      �� $	��Add��6   $��5q�6<   ��6   �� *
AddCommand+6<   �� 5#      $
��Edit��6   $	��0,5q�6>   ��6   �� *EditCommand+6>   �� 5$      $��Delete��6   $��5q�6B   ��6    �� *DeleteCommand+6B   5%      �� 5'      $��Additional Instructions��6   $��0��6.   $��1��6;   �� 5(      $��1��6   $��1��6   $��0,0,5,0q�6+   ��6<   �� *additionalText+$ TwoWay=��� 5)      $��Send With Guests��6   $��1��6(   $��2��68   $��	0,5, 5, 5q�6e   ��6E   �� *SendCommand+6e   5+      5,      