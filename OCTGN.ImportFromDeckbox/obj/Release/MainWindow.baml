   M S B A M L   `   `   `  ���� R  NOCTGN.ImportFromDeckbox, Version=1.0.0.2, Culture=neutral, PublicKeyToken=nullA%clr-namespace:OCTGN.ImportFromDeckboxOCTGN.ImportFromDeckbox  (    "OCTGN.ImportFromDeckbox.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7local%clr-namespace:OCTGN.ImportFromDeckbox       � Title$  DeckBox to OCTGN��$	��600��$	��800�� � 
ResizeMode$ NoResize=�$��14(� � WindowStartupLocation$ CenterOwner=� � 	Resources     BooleanToVisibilityConverter��%   &	        �� .���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� *   $OCTGN.ImportFromDeckbox.Localization   
SelectGame#��Z $
��Bold"�$��0��$��0,10,0,0q�.���  �� $
��Auto ��� $
��Auto �.+���  �� DisplayMemberPath$
 Name������ *GameDefinitions+ �� SelectedValue �� *SelectedGame+� $��1��$��0,3,0,0q�y��� *IsWarhammerInvasion+ �� 	Converter# [  	 � ColumnDefinitions	 �� $
��Auto ��� $��* �.+��� 
   LabelCapital#��Z
 �� $��1��$��Stretch=�$
 Name������ *WarhammerInvasionCapitals+ �� *" SelectedWarhammerInvasionCapital+��    GroupBoxHeaderDeckbox#��Z $
��Bold"�$��1��$��0,10,0,0q�.���  �� $
��Auto ��� $��* �.+��� $��Stretch=�$��WrapWithOverflow=�   ExplenationParse#��Z $��Normal"��� $��1��$	��400��$
��Left=�$��0,35,0,0q�$ �� HorizontalScrollBarVisibility$
 Auto=�$��Normal"�" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=� �� AcceptsReturn .  �� 
AcceptsTab . ���� *TextToParse+ �� UpdateSourceTrigger$ PropertyChanged=�&   System.Windows.Controls.DataGrid  $��1��$��Stretch=�   SelectionMode$ Single=�   GridLinesVisibility$ 
Horizontal=�   CanUserSortColumns .     AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .     HeadersVisibility$
 None=�   CanUserAddRows .     
IsReadOnly . "   VerticalScrollBarVisibility$
 Auto=�$	��375��$   HorizontalScrollBarVisibility$
 Auto=�$��
405,35,0,0q�$��Stretch=�$��Normal"����� *MatchedCards+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells     
IsReadOnly  . 1  +System.Windows.Controls.DataGridBoundColumn!   Binding! �� *
Quantity+  $ SizeToCells   . ! �� *	Card.Name+�� -   $��1��$��Center=�$	��Top=�"   ButtonPaste#��Z" $��5q��� -   $��Normal"�$��2��$��0,10,0,0q�$��30��#   ButtonParseAndSave#��Z# �� $��Bottom=�$��3������ .R��  �� $��* �	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.@��� $��0��$��0��.���� $ �� Orientation$$ 
Horizontal=�$��Center=�.+��� %   LoadedCards#��Z% �� $��5,0,0,0q����� *	CardCount+�� $��1����.  �� $��2��$��0��.���� $$ 
Horizontal=�$��Center=�.+��� &   ParsedCards#��Z& �� $��5,0,0,0q����� *ParsedCardCount+�� $��3����.  �� $��4��$��0��$��Center=�.���� $$ 
Horizontal=�.+��� '   MatchedCards#��Z' $��Center=��� $��5,0,0,0q�$��Center=����� *MatchedCardSummary+�� $��8��y��� *
HasError+# [  .���� $$ 
Horizontal=�.+��� $.��(molumen_red_round_error_warning_icon.png��$
��None=��� 
���  ��$
��Bold"�$��Center=����� *	ErrorHint+( � ToolTip( �� *ErrorDetails+�� $��9��$��10,0,0,0q�.���� $$ 
Horizontal=�.+��� -   )   	CopyForum#��Z) $��5,0,5,0q��� -   *   ButtonAbout#��Z* $��5,0,5,0q�$��3,0,0,0q�