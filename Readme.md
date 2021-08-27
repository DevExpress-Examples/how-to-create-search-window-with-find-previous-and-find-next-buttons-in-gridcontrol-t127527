<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128649441/14.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T127527)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DevExpress.Example01/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DevExpress.Example01/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DevExpress.Example01/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DevExpress.Example01/MainWindow.xaml.vb))
* [SearchBehavior.cs](./CS/DevExpress.Example01/SearchBehavior/SearchBehavior.cs) (VB: [SearchBehavior.vb](./VB/DevExpress.Example01/SearchBehavior/SearchBehavior.vb))
* [SearchWindow.xaml](./CS/DevExpress.Example01/SearchBehavior/SearchWindow.xaml) (VB: [SearchWindow.xaml](./VB/DevExpress.Example01/SearchBehavior/SearchWindow.xaml))
* [SearchWindow.xaml.cs](./CS/DevExpress.Example01/SearchBehavior/SearchWindow.xaml.cs) (VB: [SearchWindow.xaml.vb](./VB/DevExpress.Example01/SearchBehavior/SearchWindow.xaml.vb))
* [Task.cs](./CS/DevExpress.Example01/Task.cs) (VB: [Task.vb](./VB/DevExpress.Example01/Task.vb))
<!-- default file list end -->
# How to create Search Window with Find Previous and Find Next buttons in GridControl


<p>The example demonstrates how to create a Search window for GridControl with the Find Previous and Find Next buttons. The Search window appears on pressing the Ctrl+F keys when GridControl is focused. The search process starts automatically on typing text in the Find Text field. All matching text is highlighted in grid cells. The Previous and Next buttons allow iterating through these cells. The F3 and Shift+F3 keys also help perform the same actions by using a keyboard. In addition, the Search window theme relates to the parent's GridControl. To highlight the matching text, the SearchString property of a TreeView object in GridControl is used.</p>
<p>You can easily add full functionality of the Search window to your project by using the SearchBehavior class and attaching it as Behavior to your GridControl.</p>
<p> </p>

<br/>


