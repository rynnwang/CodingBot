
# Appropriate Audience
The .NET developers who already know how to use Beyova Common Framework to build RESTful API Services, or the one would like to be. C#/Visual Studio knowledge is definately required.

# Get Started
## 1. Prerequisite
- Visual Studio, .NET framework installed.
- Internet connected and accessibility to NuGet official site.
- Have a project case to try on.
- Create a Visual Studio solution (.NET framework 4.6.2 or above), which can have executable output (like Console, Win-Form, WPF, Unit Test, etc.). To make your life easier, Console or Unit Test project is suggested.
- Install necessary NuGet packages.
  ````````````````````````````````````````````````
    PM> Install-Package Beyova.CodingBot
  ````````````````````````````````````````````````

## 2. Define Business Model(s)
Define business models via creating interface(s) with specific attribute. Basically, if you are familiar with pattern, you can only define key functional fields. Following code is an example of define model **_Commodity_**.
  ````````````````````````````````````````````````
    using System;
    using Beyova;
    using Beyova.CodingBot;

    namespace CodingBotExample
    {
        [AutoSolutionGeneration(
            EntityName = "Commodity", 
            Pattern = EntityModelPattern.KeyIdentifier
                | EntityModelPattern.StampAudit
                | EntityModelPattern.OperatorAudit, 
            GenerationInvolvement = SolutionGenerationInvolvement.All)]
        public interface ICommodity : IIdentifier
        {
            string Name { get; set; }

            string Description { get; set; }

            DateTime? ExpiredStamp { get; set; }
        }
    }
  ````````````````````````````````````````````````
## 3. Generate Codes & Scripts
You might have to write some codes to make code generation happen. You need a method to run following example codes.

  ````````````````````````````````````````````````
  // Define options, including solution name, namespace, etc.
  ServiceSolutionCodingBotOptions options = new ServiceSolutionCodingBotOptions
  {
      UseLowerCamelNamingForJsonSeriliazation = true,
      SolutionName = "BeyovaCodingBotExample",
      NameSpace = "Beyova.CodingBot.Example"
  };

  var package = ServiceSolutionCodingBot.Generate(options);
  package.GenerateSqlPublishScript();

  // If you want to output to folder, just new FileContainer and set your root folder. 
  var storageContainer = new FileContainer(@"C:\CodingBotOutput");
  package.PutIntoStorageContainer(storageContainer);

  storageContainer.WriteToDestination();
  ````````````````````````````````````````````````
NOTES:
- **SolutionName** in **ServiceSolutionCodingBotOptions** should not contains special charactor, like dot (.)
- When **UseLowerCamelNamingForJsonSeriliazation** is set as **true**, **JsonPropertyAttribute** would be attached on each field of model to use lower case camel naming, to meet JSON naming requirement.
  ````````````````````````````````````````````````
  /// <summary>class Commodity</summary>
  public class Commodity:
      Beyova.CodingBot.UnitTest.ICommodity,
      Beyova.CodingBot.UnitTest.ICommodityEssential,
      Beyova.IIdentifier,
      Beyova.ISimpleBaseObject,
      Beyova.IBaseObject
  {
      /// <summary></summary>
      /// <value></value>
      [JsonProperty("key")]
      public System.Nullable<System.Guid> Key { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("name")]
      public System.String Name { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("description")]
      public System.String Description { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("expiredStamp")]
      public System.Nullable<System.DateTime> ExpiredStamp { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("createdStamp")]
      public System.Nullable<System.DateTime> CreatedStamp { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("lastUpdatedStamp")]
      public System.Nullable<System.DateTime> LastUpdatedStamp { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("createdBy")]
      public System.String CreatedBy { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("lastUpdatedBy")]
      public System.String LastUpdatedBy { get; set; }

      /// <summary></summary>
      /// <value></value>
      [JsonProperty("state")]
      public Beyova.ObjectState State { get; set; }

  }
  ````````````````````````````````````````````````

## 4. Customize Your Codes
If you design correctly and select right pattern(s) to use, this auto generation can help you save at least 70% time, especially at the beginning of project cycles. You can focus on the real business logics based on existed models, methods and APIs, rather than keeping boring copy-paste and troubleshooting the stupid mistakes caused by pasting something wrong.

You can:
- Add complex logic and interfaces beyond simple CRUD operations.
- Add cache, integration or any other things which can not be predict well as pattern.
- Apply DB index or/and optimize stored procedures when data size would be crazy large.
- Any other thing you just want to do.

# Advanced Documentation

## Model Pattern
It is based my personal experiences for dozons of projects. It can be multiple applied.

Pattern Name   |Pattern Value  |Mapped Interface|When to use
---------------|---------------|----------------|---------------------------------------------------------------------------------
Undefined      |0x0000         |N/A             |Default zero value of enum **_EntityModelPattern_**.
StampAudit     |0x0001         |ISimpleBaseObject|Any un-knowledge-base entity which is editable. Audit stamp is cared but not who did that.
OperatorAudit  |0x0002         |IBaseObject      |Any un-knowledge-base entity which is editable. Audit stamp and operator are cared.
GlobalName     |0x0004         |IGlobalObjectName|Entity/Object which is involved internationalization (I18N). All string based field in this case would support multiple language by default.
Snapshot       |0x0008         |ISnapshotable   |Entity/Object which need to save each snapshot/version.
KeyIdentifier  |0x0010         |IIdentifier     |Should use always. Because every object should have a Primary Key.
CodeDriven     |0x0020         |ICodeIdentifier |When this model connects/maps to a 3rd party model/object. For example, each nation/country should have an ISO-2 code, when you define class Nation, use it.

System would wisely adjust your actual pattern based your pattern value.

If your pattern value contain flag|Actual pattern value contains |Comments
----------------------------------|------------------------------|------------------------------
Undefined (0x0000)                |KeyIdentifier (0x0010)        |Like I said, any default object should have primary key (id).
StampAudit (0x0001)               |StampAudit + KeyIdentifier (0x0011)|
OperatorAudit (0x0002)            |OperatorAudit + StampAudit + KeyIdentifier (0x0013)|
GlobalName (0x0004)               |GlobalName + KeyIdentifier (0x0014)|
Snapshot (0x0008)                 |Snapshot + KeyIdentifier (0x0018)|
KeyIdentifier (0x0010)            |KeyIdentifier (0x0010)|
CodeDriven (0x0020)               |CodeDriven + KeyIdentifier (0x0030)|


# Version History
Version  |Released Date  |Beyova.Common Version|Comments
---------|---------------|---------------------|--------------------
0.1.0    |Sep 21st, 2018 |4.2.0                |Init version


