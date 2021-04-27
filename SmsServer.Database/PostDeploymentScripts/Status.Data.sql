MERGE [Status] AS Target
USING (VALUES
   (1, 'New'),
   (2, 'Sent'),
   (3, 'SendError'),
   (4, 'ServerError')) AS Source (Id,[Name])
ON (Source.Id = Target.Id)
WHEN MATCHED 
   THEN update set [Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET
   THEN insert (Id,[Name]) values (Source.Id, Source.[Name])
WHEN NOT MATCHED BY SOURCE
   THEN delete;