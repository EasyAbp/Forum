# Forum

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FForum%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.Forum.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Forum.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.Forum.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Forum.Domain.Shared)
[![Discord online](https://badgen.net/discord/online-members/S6QaezrCRq?label=Discord)](https://discord.gg/S6QaezrCRq)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/Forum?style=social)](https://www.github.com/EasyAbp/Forum)

An abp forum application module.

## Online Demo

We have launched an online demo for this module: [https://forum.samples.easyabp.io](https://forum.samples.easyabp.io)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * EasyAbp.Forum.Application
    * EasyAbp.Forum.Application.Contracts
    * EasyAbp.Forum.Domain
    * EasyAbp.Forum.Domain.Shared
    * EasyAbp.Forum.EntityFrameworkCore
    * EasyAbp.Forum.HttpApi
    * EasyAbp.Forum.HttpApi.Client
    * EasyAbp.Forum.Web

1. Add `DependsOn(typeof(ForumXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureForum();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).

## Usage

1. Create a community on the management page.

2. Go to the community home page and try to create a new post.

![CommunityList](/docs/images/CommunityList.jpeg)
![PostList](/docs/images/PostList.jpeg)
![PostDetail](/docs/images/PostDetail.jpeg)

## Road map

- [ ] User avatar.
