using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class GameStateReseter
{
    private static Dictionary<string, object> savedState = new();
    private static bool isLoaded = false;

    /// <summary>
    /// Автоматически загружает все статические переменные при старте сцены.
    /// </summary>
    public static void LoadAll()
    {
        if (isLoaded) return; // Чтобы не загружать дважды
        isLoaded = true;

        foreach (var field in GetStaticFields())
        {
            if (savedState.TryGetValue(field.Key, out var value))
            {
                field.Value.SetValue(null, value); // Восстанавливаем значение
            }
        }

        Debug.Log("✅ Все статические переменные загружены.");
    }

    /// <summary>
    /// Автоматически сохраняет все статические переменные перед выходом.
    /// </summary>
    public static void SaveAll()
    {
        foreach (var field in GetStaticFields())
        {
            savedState[field.Key] = field.Value.GetValue(null); // Сохраняем значение
        }

        Debug.Log("💾 Все статические переменные сохранены.");
    }

    /// <summary>
    /// Очищает сохраненные данные (например, перед новым запуском).
    /// </summary>
    public static void Reset()
    {
        savedState.Clear();
        Debug.Log("♻️ Все статические данные сброшены.");
    }

    /// <summary>
    /// Получает все статические переменные из пользовательских классов.
    /// </summary>
    private static Dictionary<string, FieldInfo> GetStaticFields()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && t.Namespace != null && t.Namespace.StartsWith("YourNamespace")) // Указываем свое пространство имен
            .SelectMany(t => t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            .ToDictionary(f => $"{f.DeclaringType.FullName}.{f.Name}", f => f);
    }
}
