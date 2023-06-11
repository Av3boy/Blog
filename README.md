# Blog
A .NET Blazor blog website that renders mardown files as blazor components.

## Creating a new page
1. Create a new .md markdown file in the Blogs directory.
2. Run the MarkdownConverted project.

    The MarkdownConverted project automatically reads all the files in the Blogs directory, parses the mardown into html and writes the new HTML content into the Blog/Components/Blogs diretory.
    
    NOTE: The blog .razor pages must start with a capital letter as per blazor's design. Read about blazor naming conventions [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-7.0#component-name-class-name-and-namespace).

3. Now run the 'Blog' Blazor Server app.
- All the blogs are loaded automatically using reflection using the class the .razor files generate.
- After loading, the files are then cached and loaded on initialization.

NOTE: All the blogs are found at the ```/blog/<name-of-blog-in-kebab-case>``` endpoint.

## TODO
- Cleanup the current directory structure.
- Add the 'generated' flag to the created .razor and make them readonly to make sure the user doesn't mess up the page?
- Test whether whitespaces in the .md files work.
- New design for page
- Frontpage
- Blog not found
