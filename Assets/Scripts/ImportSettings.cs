using UnityEditor;
using UnityEngine;

public static class ImportSettings
{
    public static void ApplySettings(string path)
    {
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

        if (importer != null)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
            importer.filterMode = FilterMode.Bilinear;
            importer.mipmapEnabled = false;
            importer.maxTextureSize = 512;
            importer.textureCompression = TextureImporterCompression.Compressed;

            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }
    }
}

