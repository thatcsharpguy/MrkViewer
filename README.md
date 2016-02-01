MkrViewer is a simple yet powerful markdown viewer for mobile (and desktop) platforms. 

MrkViewer leverages all the capabilities provided by the CommonMark specification which is used in many other applications across the web (like Stack Overflow).  

**This is only a viewer** no plans for adding editor features in the near future.  
  
### But why?  
Some time ago I bought a cheap Microsoft Surface RT that ended up not being so useful (we can all agree that Windows RT isn't the best OS, right?), I didn't wanted to keep collecting dust with it so I decided to turn it into a markdown reader.  
  
I tried several apps (even some paid ones) but no one convinced me, that's when I opened Visual Studio and started this app.

### Tech stuff 
This app is built using Xamarin.Forms (to get the app in as many platforms as possible) even though the "viewer" is implemented using a `WebView` control where the converted Markdown is rendered.  

Speaking of markdown-to-html conversion, the CommonMark implementation for C# is provided by [CommonMark.NET](https://github.com/Knagis/CommonMark.NET).  
  
### Downloads  
Feel like building your own version? [get the source code](https://github.com/fferegrino/MrkViewer).  
  
Just want to use it? it is available in  
  
 - <a target="_blank" href="https://www.microsoft.com/en-us/store/apps/mrkviewer/9nblggh6jssm">Microsoft Store</a>  
 

### Support, bugs and feature requests
First of all, if you are here to give feedback, I want to thank you for using MrkViewer and for helping me to improve this app, that being said:  

Please use the <a href="https://github.com/fferegrino/MrkViewer/issues/new" target="_blank">issues system</a> on GitHub to report any bug or request features.  
	
