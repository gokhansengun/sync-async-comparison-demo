## Summary

This repository is used in the blog post digging database transaction internals below.

[www.gokhansengun.com/asp-net-mvc-and-web-api-comparison-of-async-or-sync-actions](www.gokhansengun.com/asp-net-mvc-and-web-api-comparison-of-async-or-sync-actions)

## Excerpt from the blog post

ASP.NET provides async actions starting with .NET 4.5. Nowadays asynchronism is a trendy subject which nobody could just ignore or resist to adapt. In this blog, we will try to dig what it brings to the table and how it compares with the good old synchronous approach we have happily used for years. Instead of giving only the assertions, we will create sample programs and observe the behaviour while it is happening. This approach will hopefully help understand how ASP.NET processes the requests when it comes to the thread management. There is no big difference between handling of MVC and Web API actions, for ease of demonstration we will use Web API here. Almost evertyhing stated and demonstrated for Web API will be valid for MVC too.

### Work Summary

In the blog, we will try to compare and contrast async and sync actions from various aspects in the use cases.

* We will first introduce async actions by comparing the behaviour of async and sync actions.
* We will then cite the use cases and discuss where async actions just fit better and where sync actions shine.
* We will finally create some programs to prove the assertions and also learn how ASP.NET processes the requests. 
