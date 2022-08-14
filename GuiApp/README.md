## Caliburn.Micro Example
### Course 1: Wiring Events
* Convention:
```xaml
<!-- ShellView.xaml -->
<Button x:Name="Save">
```

This will cause the Click event of Button to call the "Save" method on the ViewModel.

```cs
// ShellViewModel.cs

public void Save(){
    /* Write down the logic below */
}
```

* Short Syntax

```xaml
<Button cal:Message.Attach="Save">
```
This will again cause the Click event of Button to call the "Save" method on the ViewModel.
```cs
// ShellViewModel.cs

public void Save(){
    /* Write down the logic below */
```
Different events can be used like this:
```xaml
<Button cal:Message.Attach="[Event MouseEnter] = [Action Save]">
```
Different parameters can be passed to the method like this:
```xaml
<Button cal:Message.Attach="[Event MouseEnter] = [Action Save($this)]">
```

* $eventArgs

Pass the orginal EventArgs or input parameter to your Action. Note: this will be full null for guard methods since the trigger hasn't acctually occured. 

* $dataContext

Pass the DataContext of the element that the ActionMessage is attached to. This is very useful in Master/Detail scenarios where the ActionMessage may bubble to a parent VM but needs to carry with it the child instance to be acted upon.

* $source

The actual FrameworkElement that triggered the ActionMessage to be sent.

* $View

The view(usually a UserControl or Window) that is bound to the ViewModel.

* $executionContext

The action's execution context, which contains all the above information and more. This is useful in advanced scenarios.

* $this

The actual UI element which the action is attached. In this case, the element itself won't be passed as a parameter, but rather its default property.





### Course 2: Databing  