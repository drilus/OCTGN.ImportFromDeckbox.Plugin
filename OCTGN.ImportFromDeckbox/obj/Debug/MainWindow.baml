   M S B A M L   `   `   `  ����R  NOCTGN.ImportFromDeckbox, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullA%clr-namespace:OCTGN.ImportFromDeckboxOCTGN.ImportFromDeckbox  5   	   (    "OCTGN.ImportFromDeckbox.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7local%clr-namespace:OCTGN.ImportFromDeckbox     5   	     � Title$  DeckBox to OCTGN��5   	   $	��600��6"   $	��800��6/    � 
ResizeMode$ NoResize=�5   	   $��14(�5   	    � WindowStartupLocation$ CenterOwner=�6    � 	Resources 5	          BooleanToVisibilityConverter��%   &	        �� 5
   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� *   $OCTGN.ImportFromDeckbox.Localization   
SelectGame#��Z 6   $
��Bold"�6E   $��0��6W   $��0,10,0,0q�6d   .��5      �  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      ��  �� DisplayMemberPath$
 Name��6C   ��6   �� *GameDefinitions+ �� SelectedValue 6\   �� *SelectedGame+� 5      $��1��6   $��0,3,0,0q�6$   y�65   �� *IsWarhammerInvasion+ �� 	Converter# [  	 � ColumnDefinitions	 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5!      �� 
   LabelCapital#��Z
 6   �� 5"      $��1��6   $��Stretch=�6/   $
 Name��5#      ��5$      �� *WarhammerInvasionCapitals+ 5%      �� *" SelectedWarhammerInvasionCapital+5&      5'      5(      �� 5*   
      GroupBoxHeaderDeckbox#��Z 6   $
��Bold"�6P   $��1��6b   $��0,10,0,0q�6o   .��5+      �  5,      �� 5-      $
��Auto �6$   �� 5.      $��* �6$   .+�50      �� $��Stretch=�6   $��WrapWithOverflow=�6:      ExplenationParse#��Z 6Z   $��Normal"�6�   �� 52      $��1��6   $	��400��6'   $
��Left=�63   $��0,35,0,0q�53      $ �� HorizontalScrollBarVisibility$
 Auto=�54   W   $��Normal"�55      " �� VerticalScrollBarVisibility$
 Auto=�6-    �� TextWrapping$
 Wrap=�6P    �� AcceptsReturn .  �� 
AcceptsTab . ��54      �� *TextToParse+ �� UpdateSourceTrigger$ PropertyChanged=�56      &   System.Windows.Controls.DataGrid  59      $��1��6   $��Stretch=�6(      SelectionMode$ Single=�5:         GridLinesVisibility$ 
Horizontal=�62      CanUserSortColumns .     AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .     HeadersVisibility$
 None=�5?         CanUserAddRows .     
IsReadOnly . "   VerticalScrollBarVisibility$
 Auto=�5B      $	��375��5C      $   HorizontalScrollBarVisibility$
 Auto=�5D      $��
405,35,0,0q�5E      $��Stretch=�5F      $��Normal"�5G      ��59   F   �� *MatchedCards+   Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6.       
IsReadOnly  . 1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6T   �� *
Quantity+  5J      $ SizeToCells 6/     . ! 6U   �� *	Card.Name+5L      �� 5N      -   5        $��1��5N      $��Center=�6&   $	��Top=�6C   "   ButtonPaste#��Z" 6[   $��5q�5O      6%   5Q      5R      �� 5T   
   -   5        $��Normal"�5T      $��2��6%   $��0,10,0,0q�63   $��30��6E   #   ButtonParseAndSave#��Z# 6Q   6�   �� 5U   
   $��Bottom=�6   $��3��6,   ��5V      �� 5W      .R�5X      �  5Y      �� 5Z      $��* �6,   	 5\      �� 5]      $
��Auto �6/   �� 5^      $
��Auto �6/   �� 5_      $
��Auto �6/   �� 5`      $
��Auto �6/   �� 5a      $
��Auto �6/   �� 5b      $
��Auto �6/   �� 5c      $
��Auto �6/   �� 5d      $��* �6/   �� 5e      $
��Auto �6/   �� 5f      $
��Auto �6/   �� 5g      $
��Auto �6/   �� 5h      $
��Auto �6/   �� 5i      $
��Auto �6/   5k      5l      .@�5n      �� $��0��6   $��0��6,   .��5o      �� $ �� Orientation$$ 
Horizontal=�6   $��Center=�66   .+�5p      �� %   LoadedCards#��Z% 6    �� 5q      $��5,0,0,0q�6    ��61   �� *	CardCount+5r      5s      �� 5v      $��1��6   ��.  6(   �� 5y      $��2��6   $��0��6,   .��5z      �� $$ 
Horizontal=�6   $��Center=�66   .+�5{      �� &   ParsedCards#��Z& 6    �� 5|      $��5,0,0,0q�6    ��61   �� *ParsedCardCount+5}      5~      �� 5      $��3��6   ��.  6(   �� 5�      $��4��6   $��0��6,   $��Center=�69   .��5�      �� $$ 
Horizontal=�6   .+�5�      �� '   MatchedCards#��Z' 6    $��Center=�6R   �� 5�      $��5,0,0,0q�6    $��Center=�6U   ��61   �� *MatchedCardSummary+6U   5�      5�      �� 5�      $��8��6   y�6,   �� *
HasError+# [  .��5�      �� $$ 
Horizontal=�6   .+�5�      �� $.��(molumen_red_round_error_warning_icon.png��6   $
��None=�6N   �� 5�      
���  ��$
��Bold"�6q   $��Center=�5�      ��5�       �� *	ErrorHint+( � ToolTip( 6;   �� *ErrorDetails+5�      5�      5�      �� 5�      $��9��6   $��10,0,0,0q�6,   .��5�      �� $$ 
Horizontal=�6   .+�5�      �� -   5        )   	CopyForum#��Z) 5�      $��5,0,5,0q�6e   �� 5�      -   5        *   ButtonAbout#��Z* 5�      $��5,0,5,0q�6f   $��3,0,0,0q�6x   5�      5�      5�      5�      5�      