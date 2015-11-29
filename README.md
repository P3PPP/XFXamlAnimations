# XFXamlAnimations

__XFXamlAnimations__ is a library to define the animation in Xamarin Forms XAML.

## Example usage

At first, call `XFXamlAnimations.XamlAnimations.Init();` in constructor of App class.

```
public App()
{
	XFXamlAnimations.XamlAnimations.Init();
	MainPage = new MyPage();
}
```

Next, use `BeginStoryBoard` action in XAML to start animations. A StoryBoard can include Animations and StoryBoards.

```
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
			 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 xmlns:xa="clr-namespace:XFXamlAnimations;assembly=XFXamlAnimations"
			 x:Class="Sample.MyPage">
	<ContentPage.Content>
		<Button x:Name="button" Text="Begin animation">
		    <Button.Triggers>
		        <EventTrigger Event="Clicked">
		            <xa:BeginStoryBoard>
		                <xa:BeginStoryBoard.StoryBoard>
		                    <xa:ParallelStoryBoard>
		                        <xa:RelRotateToAnimation Target="{x:Reference button}"
		                                                 Rotation="360"
		                                                 Duration="1000"
		                                                 Easing="BounceOut" />
		                    </xa:ParallelStoryBoard>
		                </xa:BeginStoryBoard.StoryBoard>
		            </xa:BeginStoryBoard>
		        </EventTrigger>
		    </Button.Triggers>
		</Button>
	</ContentPage.Content>
</ContentPage>
```

## Parallel animation

```
<xa:ParallelStoryBoard>
	<xa:RelRotateToAnimation Target="{x:Reference box1}"
							 Rotation="-360"
							 Duration="1000" />
	<xa:RelRotateToAnimation Target="{x:Reference box2}"
							 Rotation="360"
							 Duration="1000" />
</xa:ParallelStoryBoard>
```

## Sequential animation

```
<xa:SequentialStoryBoard>
	<xa:RelRotateToAnimation Target="{x:Reference box1}"
							 Rotation="-360"
							 Duration="1000" />
	<xa:RelRotateToAnimation Target="{x:Reference box2}"
							 Rotation="360"
							 Duration="1000" />
</xa:SequentialStoryBoard>
```

## Animatoins defined in `Xamarin.Forms.ViewExtentions`

* FadeToAnimation (Opacity)
* LayoutToAnimation (Bounds)
* RelRotateToAnimation (Rotation)
* RelScaleToAnimation (Scale)
* RotateToAnimation (Rotation)
* RotateXToAnimation (Rotation)
* RotateYToAnimation (Rotation)
* ScaleToAnimation (Scale)
* TranslateToAnimation (X and Y)

## Property based animaton

```
<xa:ColorAnimation Target="{x:Reference box1}"
				   TargetPropertyName="Color"
				   From="Blue"
				   To="Green"
				   Duration="1500" />

<xa:DoubleAnimation Target="{x:Reference box1}"
					TargetPropertyName="WidthRequest"
					From="130"
					To="260"
					Duration="1000" />
```

## License

The MIT License (MIT)
