   M S B A M L   `   `   `  ����R  NOCTGN.ImportFromDeckbox, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullA%clr-namespace:OCTGN.ImportFromDeckboxOCTGN.ImportFromDeckbox  5   	   &     OCTGN.ImportFromDeckbox.AboutBox   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:OCTGN.ImportFromDeckbox     5   	   $	��550��5   	   $	��400��5	   	     � 
ResizeMode$  NoResize=�5   '    � Title 6	   �� *CustomTitle+.��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   .+�5!      �� $��0��6   $��2��6%   $
��Wrap=�6W   ��69   �� *Description+6W   �� 5"      $��1��6   $��2��6%   *   $OCTGN.ImportFromDeckbox.Localization   AboutboxAuthor#��Z 69   $
��Wrap=�5#      $��0,3,0,0q�5$      �� 5&      $��0,10,0,0q�6   $��2��6&      AboutboxHeader#��Z 63   $
��Bold"�6j   &   System.Windows.Controls.DataGrid  5'      $��3��6   $��Stretch=�6$      SelectionMode$ Single=�6r      GridLinesVisibility$ 
Horizontal=�6�      CanUserSortColumns .  	   AutoGenerateColumns	 .  |�.  
 J� IsHitTestVisible
 .     CanUserReorderColumns .     CanUserResizeColumns .     HeadersVisibility$
 None=�5(   �   $	��100��5)         CanUserAddRows .     
IsReadOnly . "   VerticalScrollBarVisibility$
 Auto=�5*      $   HorizontalScrollBarVisibility$
 Auto=�5+      ��5'   B   �� *VersionDetailCollection+   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      #   AboutboxVersionHeaderVersion,  &System.Windows.Controls.DataGridColumn   Header# Z 6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6n      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *	Version+  5.      #   AboutboxVersionHeaderDetails# Z 6*   $ SizeToCells 6n    .  6�   �� *	Details+50      9� 52         AboutboxLicenceHeader#��Z 6   $��0,10,0,0q�6T   $��4��6f   $��2��6s   $��Stretch=�53      .��54      �� $��5��6      AboutboxLicence#��Z 6'   $	��110��55       �� 
IsReadOnly . $ �� HorizontalScrollBarVisibility$
 Auto=�56   $   " �� VerticalScrollBarVisibility$
 Auto=�6I   $��Stretch=�57      $��Stretch=�58      59      5:      �� 5;   
   $��Right=�6    �� 	IsDefault .  �� IsCancel . $��0,10,0,0q�5<      $��1��6#   $��80��60       ButtonClose#��Z  6>   5=      5>      