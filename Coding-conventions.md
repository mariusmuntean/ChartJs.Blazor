#### Note that these are not fully enforced throughout the library. From now on use these conventions when implementing or reworking features. For bug fixes and small features it should be preferred to follow the already present style. Do not submit pull requests which only fix coding conventions.

# Coding style

Our coding style is inspired by the [.NET coding style](https://github.com/dotnet/runtime/blob/master/docs/coding-guidelines/coding-style.md). It was also discussed in [ChartJs.Blazor#58](https://github.com/mariusmuntean/ChartJs.Blazor/issues/58) (or more so [Joelius300/ChartJSBlazor#22](https://github.com/Joelius300/ChartJSBlazor/issues/22)).

1. We use [Allman style](http://en.wikipedia.org/wiki/Indent_style#Allman_style) braces, where each brace begins on a new line. A single line statement block can go without braces in certain situations (see rule 16 for more details). One exception is that a `using` statement is permitted to be nested within another `using` statement by starting on the following line at the same indentation level, even if the nested `using` contains a controlled block.
   Another exception is empty constructors. There you should use `{ }`. The reason for that is that we have a lot of empty constructors due to the string- and object enums. Therefore we stick with `{ }` for now.
   Example: `public LineDataset() : base(ChartType.Line) { }`

2. We use four spaces of indentation (no tabs).

3. We use `_camelCase` for internal and private fields and use `readonly` where possible. Prefix internal and private instance fields with `_`, static fields with `s_` and thread static fields with `t_`. When used on static fields, `readonly` should come after `static` (e.g. `static readonly` not `readonly static`).  Public fields should be used sparingly and should use PascalCasing with no prefix when used.

4. We avoid `this.` unless absolutely necessary.

5. We always specify the visibility, even if it's the default (e.g.
   `private string _foo` not `string _foo`). Visibility should be the first modifier (e.g. `public abstract` not `abstract public`).

6. Namespace imports should be specified at the top of the file, *outside* of
   `namespace` declarations. Sorting them (alphabetically) is nice but not required.

7. Avoid more than one empty line at any time. For example, do not have two
   blank lines between members of a type.

8. Avoid spurious free spaces.
   For example avoid `if (someVar == 0)...`, where the dots mark the spurious free spaces.
   Consider enabling "View White Space (Ctrl+R, Ctrl+W)" or "Edit -> Advanced -> View White Space" if using Visual Studio to aid detection.

9. If a file happens to differ in style from these guidelines (e.g. static members are named `member`
   rather than `s_member`), the existing style in that file takes precedence. This only applies for small changes. When reworking the entire file consider adjusting the style unless it causes a breaking change.

10. We only use `var` when it's obvious what the variable type is (e.g. `var stream = new FileStream(...)` not `var stream = OpenStandardInput()`). When unsure use the explicit type.

11. We use language keywords instead of BCL types (e.g. `int, string, float` instead of `Int32, String, Single`, etc) for both type references as well as method calls (e.g. `int.Parse` instead of `Int32.Parse`).

12. We use PascalCasing to name all our constant local variables and fields. The only exception is for interop code where the constant value should exactly match the name and value of the code you are calling via interop.

13. We use ```nameof(...)``` instead of ```"..."``` whenever possible and relevant (semantically correct).

14. Fields should be specified at the top within type declarations.

15. When including non-ASCII characters in the source code use Unicode escape sequences (\uXXXX) instead of literal characters. Literal non-ASCII characters occasionally get garbled by a tool or editor.

16. When using a single-statement if, we follow these conventions:
    
    - Never use single-line form (for example: `if (source == null) throw new ArgumentNullException("source");`)
    
    - Braces may only be omitted if the single line statement after the `if` is a `return` or `throw` statement. Otherwise use braces.
      Examples: 
      
      ```csharp
      if (value == null)
          throw new ArgumentNullException(nameof(value));
      ```
      
      ```csharp
      if (size.HasValue)
          return size.Value;
      ```
      
      ```csharp
      if (time < lastEntry)
      {
          time = DateTime.MaxValue;
      }
      ```

17. When creating new structs, make them `readonly` unless there's a specifc reason not to. Use readonly properties, not fields.

18. Only have one class per file. Exceptions are: 
    
    - Nested classes. Consider using two files along with making the parent class `partial` if it makes sense.
    
    - Generic and non-generic version of the same interface or class. For example `IDataset` and `IDataset<T>` should both be in the file `IDataset.cs`. When classes are too big or they should be separated more clearly use the `IDatasetOfT.cs` convention for naming the file. If there's only a generic version drop the suffix and name it `IDataset`.

19. Lines should generally not exceed 100 characters. There can be exceptions (like links in summaries) but consider using line breaks to shorten lines and improve readability.

# Documentation

Since this is a library, the documentation is really important. Every publicly visible type or member (except for equality methods and very obvious cases like `Direction.Left`) must have a description in the form of a `<summary>` tag applied to them.

1. The description is in english. We strive to create a language and culture independant library but currently do not have interest in localizing it.

2. Terminate all descriptions with a period (.). This also applies to descriptions of parameters.

3. For properties we use the form `Gets or sets ...`. For readonly properties we use `Gets ...`.

4. For boolean properties we use the form `Gets or sets a value indicating whether or not ...`.

5. For properties modeled after Chart.js, try to use the description provided by [their docs](https://www.chartjs.org/docs/latest/). Adjust them for the form described in point 3 and 4. Also if they reference something like another property, use a `<see />` tag whenever possible.

6. For classes, consider using the form `Represents ...`. This should be the start, point 12 follows.

7. For methods, consider starting with a verb in the third person (`Adds`, `Updates`,  `Checks`, etc).

8. For all color properties (currently of type `string`), add the following parameter about colors:
   
   ```xml
   /// <para>See <see cref="ColorUtil"/> for working with colors.</para>
   ```

9. For constructors use the form `Creates a new instance of <see cref="X"/>.`. Additional information can be added in a new sentence or injected into that form so it still makes sense.  
   For example: 
   `Creates a new instance of <see cref="LineDataset{T}"/> with inital data.`

10. Use the `<see/>` tag whenever semantically correct. Use `<see langword="X"/>` for `true`, `false` and `null`. The tag should be closed directly with `/>` and there shouldn't be any whitespace before the closing.

11. Use the `<a>` tag when referencing a website. For classes modeled after Chart.js, link the appropriate [Chart.js documentation](https://www.chartjs.org/docs/latest/) page. For properties that need more details or benefit from an external reference, link an official source like the [MDN web docs](https://developer.mozilla.org).

12. Add a notice in the following form for classes modeled after something and for unclear properties. An example is Chart.js options which should always have a corresponding docs page. Another option is the `BorderDash` property which highly benefits from a link to MDN.
    The text displayed should be _As per documentation [here (source)](https://example.org/)_. Common sources might be `Chart.js`, `MDN`, `MS docs`.
    
    ```xml
    /// As per documentation <a href="https://developer.mozilla.org/en-US/docs/Web/...">here (MDN)</a>.
    ```
    
    ```xml
    /// As per documentation <a href="https://www.chartjs.org/docs/latest/general/...">here (Chart.js)</a>.
    ```

13. For the equality methods (`object.Equals`, `IEquatable.Equals`, `object.GetHashCode`) and the equality operators (`==`, `!=`) either add the summaries or disable the warning with the following pragmas. The other members should all have descriptions.
    
    ```
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    ```
