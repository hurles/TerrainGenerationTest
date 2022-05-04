// See https://aka.ms/new-console-template for more information
using Hsc.World.TerrainGenerator.Core.Generation;
using Hsc.World.TerrainGenerator.Core.Model.ModelLoader;
using System.Text;
using TerrainGeneratorTest;

Console.WriteLine("Generating chunks..");

var helper = new WorldHelper();
var terrainGenerator = new TerrainGenerator(Definitions.GetWorldDefinition(), helper);
await terrainGenerator.GenerateTerrainAsync();

List<string> lines = new();

StringBuilder log = new StringBuilder();

Console.WriteLine("Generating map..");

for (int y =0; y < 300; y++)
{
    string line = "";
    for (int x = 0; x < 300; x++)
    {
        var tile = await terrainGenerator.GetTileAsync(x, y);
        if (tile != null)
        {
           var rTile = helper.GetRandomTileFromGroup(tile.TileTypeId);
            line += helper.GetTileDefinition(rTile).Name;
            // line += $"[{x},{y}]";
            log.Append($"[{x},{y}]");
        }
    }
    log.Append("\n");
    lines.Add(line);
}

Console.WriteLine("Saving..");

var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Testies");
Directory.CreateDirectory(path);

await File.WriteAllLinesAsync(path + "\\" + "test" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString() + ".txt", lines);
await File.WriteAllTextAsync(path + "\\" + "log" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString() + ".txt", log.ToString());

Console.WriteLine("Done..");

Console.ReadKey();
