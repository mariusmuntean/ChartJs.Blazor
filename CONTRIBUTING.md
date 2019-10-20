# ChartJSBlazor Contributor's guide
Here is our guidance for how to propose new features and submit contributions via Pull Requests (PR). This is loosely modelled after the [microsoft/terminal](https://github.com/microsoft/terminal/blob/master/doc/contributing.md) and the [www.opensource.guide](https://opensource.guide/how-to-contribute) Guidelines

## Before you start, file an issue
To eliminate unnecessary effort and frustration and to ensure no one wastes time please file an issue before doing anything else.

### How to file an issue
Before filing a new issue, please look through already existing issues. Search open and closed issues first, it may be that someone else has already found the problem you have and has filed an issue. Please don't clutter up the repo with duplicate issues.  

Also, if something isn't working like you expect it to, I really encourage you to look at the actual [chart.js-docs](https://www.chartjs.org/docs/latest/) before submitting an issue. It's also always helpful if you include a reference to the official docs to back you up when opening an issue about wrong behaviour.  
Since there are a lot of options for chart.js, it's really easy to miss small errors which can cause trouble. Show us your research if you find one :)

If no existing issue describes the problem / feature idea you have: Great! - please file a new issue

### File a new Issue
- Have a question that you don't see answered in our (sparse) documentation? File an issue
- Want to know if we're planning on implementing a new feature? File an issue
- Got a great idea for a new feature? File an issue
- Found an existing issue that describes yours? Great - upvote and add additional commentary/ info/ repro-steps/ etc.

### Flesh out your issue
This is based off of [Section 5 of the opensource guide to contributing](https://opensource.guide/how-to-contribute/#how-to-submit-a-contribution)

- **Give Context** help us help you by giving context to the why/ how of your issue
- **Do some research beforehand** Not knowing everything is ok but show that you tried. Please don't ask questions we can answer with a simple google search or with a link to another issue
- **Keep them short and direct** The shorter and more direct an issue is, the faster we can understand it and help you
- **Ask questions** Everyone starts out not knowing anything about a project, don't be afraid to ask us well researched questions
- **Above all be nice and respectful**

## Contributing fixes and features
For those able and willing to help fix issues and/ or implement features:

### Development
### Fork, Clone, Branch and Create your PR
Once you have created an issue, discussed the issue with other contributors and the maintainer and you have agreed on an approach, it is time to start development:

1. Fork the repo (if you haven't already)
2. Clone your fork locally
3. Create & push a feature branch
4. Rebase onto master to eliminate merge conflicts (if you're unsure what a rebase is, [here](https://hackernoon.com/dont-fear-the-rebase-bca683888dae) is an excellent blog post)
5. Create a Pull Request

After this process, your PR will be reviewed by the Maintainer and either be accepted, merged into master and closed or be rejected with comments and instructions on improvements and fixes