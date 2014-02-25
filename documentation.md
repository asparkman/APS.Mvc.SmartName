#What Does It Do?

I hate writing Display attributes.  If the client or end-user ever wants to change a field name, two places need to be edited.  While they may be close, one can often be overlooked.

The view model member name is usually descriptive enough to describe it.  So how does this project solve this problem?

ASP.NET MVC has a back-end class that aggregates all of the ComponentModel annotations into one object.  The aggregation is done whenever a view is called, and it is performed on the model class of that view.  When the view is being rendered, it then uses that object to determine the outputs of the various HTML Helper extension methods like Html.LabelFor, Html.DisplayFor, and Html.EditorFor.

This project provides an extension to the back-end class that does the aggregating.  Basically, the extension takes the member names of the model, and breaks them up into human-readable labels.  The process is very straightforward.
# If a Display annotation exists for the member, use it with no modifications, otherwise continue with the following steps.
# Break it up based on the stylistic convention - camel case or underscore delimited - into a list of words.
# Capitalize the common acronyms, so acronyms like Xml and Id appear as XML and ID to the user.
# Decapitalize the prepositions.
# Decapitalize the articles.

#How To Use

Add the following to the Application_Start() method of the Global.asax file.

	ModelMetadataProviders.Current = new SmartDisplayNameMetaDataProvider();
	DescriptiveNameProvider.Current = new NameConventionUtility();
	
#Further Configuration

* appSettings
** DecapitalizePrepositions
*** Purpose: If set it will decapitalize prepositions. 
*** Default Value: true
** DecapitalizeArticles
*** Purpose: If set it will decapitalize articles. 
*** Default Value: true
** CapitalizeAcronyms
*** Purpose: If set it will capitalize acronyms. 
*** Default Value: true

The various special words (prepositions, articles, acronyms) may all be customized through the List<string> members of the NameConventionUtility.  The set of words considered acronyms is determined by the Acronyms member.  This is also the case for prepositions with the Prepositions member, and likewise for articles with the Articles member.

