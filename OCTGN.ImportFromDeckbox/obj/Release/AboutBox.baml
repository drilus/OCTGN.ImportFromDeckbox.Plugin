   M S B A M L   `   `   `  ���� R  NOCTGN.ImportFromDeckbox, Version=1.0.0.2, Culture=neutral, PublicKeyToken=nullA%clr-namespace:OCTGN.ImportFromDeckboxOCTGN.ImportFromDeckbox  &     OCTGN.ImportFromDeckbox.AboutBox   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:OCTGN.ImportFromDeckbox     $	��550��$	��400��  � 
ResizeMode$  NoResize=� � Title �� *CustomTitle+.��� $��5q� � RowDefinitions �� $��* ��� $
��Auto �.+��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $��* �.+��� $��0��$��2��$
��Wrap=����� *Description+�� $��1��$��2��*   $OCTGN.ImportFromDeckbox.Localization   AboutboxAuthor#��Z $
��Wrap=�$��0,3,0,0q��� $��0,10,0,0q�$��2��   AboutboxHeader#��Z $
��Bold"�&   System.Windows.Controls.DataGrid  $��3��$��Stretch=�   SelectionMode$ Single=�   GridLinesVisibility$ 
Horizontal=�   CanUserSortColumns .  	   AutoGenerateColumns	 .  |�.  
 J� IsHitTestVisible
 .     CanUserReorderColumns .     CanUserResizeColumns .     HeadersVisibility$
 None=�$	��100��   CanUserAddRows .     
IsReadOnly . "   VerticalScrollBarVisibility$
 Auto=�$   HorizontalScrollBarVisibility$
 Auto=����� *VersionDetailCollection+   Columns 0  *System.Windows.Controls.DataGridTextColumn  #   AboutboxVersionHeaderVersion,  &System.Windows.Controls.DataGridColumn   Header# Z    Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Version+  #   AboutboxVersionHeaderDetails# Z $ SizeToCells  .  �� *	Details+9�    AboutboxLicenceHeader#��Z $��0,10,0,0q�$��4��$��2��$��Stretch=�.���� $��5��   AboutboxLicence#��Z $	��110�� �� 
IsReadOnly . $ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=�$��Stretch=�$��Stretch=��� $��Right=� �� 	IsDefault .  �� IsCancel . $��0,10,0,0q�$��1��$��80��    ButtonClose#��Z  