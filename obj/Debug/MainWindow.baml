   M S B A M L   `   `   `  ����B  >OBJ2GL2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OBJ2GL2OBJ2GL2  5   	   _ [HelixToolkit.Wpf.SharpDX, Version=2.5.1.0, Culture=neutral, PublicKeyToken=52aa3500039caf0dwQclr-namespace:HelixToolkit.Wpf.SharpDX.Controls;assembly=HelixToolkit.Wpf.SharpDX!HelixToolkit.Wpf.SharpDX.Controls 5   9       OBJ2GL2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OBJ2GL2     5   	   -hx$http://helix-toolkit.org/wpf/SharpDX  5   	   `ControlsQclr-namespace:HelixToolkit.Wpf.SharpDX.Controls;assembly=HelixToolkit.Wpf.SharpDX  69   -   5          �Name$  MWindow��5   �    � Title$ OBJ2GL2��5	   	   $	��531��6   $
��1441��6&   ���	#FF212121 � 
ResizeMode$ NoResize=�6J   .��5
      � .+�5   
   �� -   5         ��Name$ 
ButtonLoad��5      $
��Load��6%   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5         ��Name$ tbdata��5      $��
10,56,0,32q�6"    �� TextWrapping$
 Wrap=�66   " �� VerticalScrollBarVisibility$
 Auto=�6J   
������� �� 
IsReadOnly . $
��Left=�6�   $	��312��6�   ��6m   Z� ��6�   Z� 6�   �� 5   
   -   5        $ ButtonParse��5      $��Parse��6&   $
��Left=�66   $��	99,10,0,0q�6Q   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5         ��Name$ chboxX��5      $��X��6#   $
��Left=�6/   $��
625,35,0,0q�6J   $	��Top=�6^   $	��157��6v   
�������{�.  6�   �� 5   
   -   5        $ chboxY��5      $��Y��6#   $
��Left=�6/   $��
625,55,0,0q�6J   $	��Top=�6^   $	��157��6v   
�������{�.  6�   �� 5   
   -   5        $ chboxZ��5      $��Z��6#   $
��Left=�6/   $��
625,75,0,0q�6J   $	��Top=�6^   $	��157��6v   
�������{�.  6�   �� 5   
   -   5        $ chboxFullCode��5      $��Full OpenGL code��6*   $
��Left=�6E   $��
625,95,0,0q�6`   $	��Top=�6t   $	��157��6�   
�������	 d� 	IsChecked$
	 TrueY�6�   �� 5   
   -	   5        $ tbScale��5      $
��Left=�6#   $��23��6>   $��625,245,0,0q�6J   $
 Wrap=�6_   $	��0.5��6s   $	��Top=�6~   $	��157��6�   $��Center=�6�   $��Center=�6�   ���	#FFDDDDDD6�   �� 5   
   -
   5        $ 
chboxScale��5      $��Scale��6'   $
��Left=�67   $��625,225,0,0q�6R   $	��Top=�6g   $	��157��6   
�������6�   �� 5   
   -   5        $ chboxFastscale��5      $��	Fastscale��6+   $
��Left=�6?   $��625,273,0,0q�6Z   $	��Top=�6o   $	��157��6�   
�������6�   �� 5   
   -   5        $ chboxDiscomode��5      $��	Discomode��6+   $
��Left=�6?   $��329,104,0,0q�6Z   $	��Top=�6o   $��83��6�   
�������6�   �� 5   
   -   5        $ chboxOffset��5      $��Offset��6(   $
��Left=�69   $��625,205,0,0q�6T   $	��Top=�6i   $	��157��6�   
�������{�.  6�   �� 5   
   -   5        $ chboxDiscomode_Async��5      $��
Async rave��61   $
��Left=�6F   $��457,152,0,0q�6a   $	��Top=�6v   $��83��6�   
�������{�.  6�   �� 5   
   -   5        $ chboxColorOverride��5      $��Color override��6/   $��
329,35,0,0q�6H   $	��Top=�6\   
�������$
��Left=�6�   $	��111��6�   �� 5   
   -   5        $ tbColorData��5      $��23��6'   $��
440,56,0,0q�63   $
 Wrap=�6G   $��(20,230,60)��6[   $	��Top=�6n   $��Center=�6�   $��Center=�6�   ���	#FFDDDDDD$
��Left=�6�   $	��122��6�   �� 5   
   $��Color data (r,g,b)��6   $
��Left=�6-   $��
327,56,0,0q�6H   $	��Top=�6\   
�������6t   �� 5   
   -   5        $ tbDiscoInterval��5      $
��Left=�6+   $��23��6F   $��440,124,0,0q�6R   $
 Wrap=�6g   $	��200��6{   $	��Top=�6�   $	��120��6�   ���	#FFDDDDDD$��Center=�6�   $��Center=�6�   �� 5   
   $��Disco interval��6   $
��Left=�6)   $��327,124,0,0q�6D   $	��Top=�6Y   
�������6q   *  $HelixToolkit.Wpf.SharpDX.Viewport3DX  5   
   -   5        
  Name$
 MainViewport3DX��5      $��806,10,10,10q�62      EnableD2DRendering .     EnableSwapChainRendering . 6c   5      5!      