using IgbTreeGrid_Icons.Icons;
using IgbTreeGrid_Icons.Models;
using IgniteUI.Blazor.Controls;

namespace IgbTreeGrid_Icons;

public partial class App
{
    private enum IconSet
    {
        MaterialIcons,
        MaterialSymbols,
    }

    // アイコンの登録 / 参照変更 API を呼び出すための非表示 IgbIcon
    private IgbIcon? iconRegistry;

    private IReadOnlyList<Employee> Employees { get; } = EmployeeData.Create();

    private IconSet CurrentIconSet { get; set; } = IconSet.MaterialIcons;

    private bool IsIconRegistryReady { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender || this.iconRegistry is null)
        {
            return;
        }

        await this.iconRegistry.EnsureReady();
        await RegisterMaterialSymbolsAsync(this.iconRegistry);

        this.IsIconRegistryReady = true;
        this.StateHasChanged();
    }

    private async Task OnIconSetSelected(IgbComponentValueChangedEventArgs args)
    {
        if (this.iconRegistry is null || !Enum.TryParse<IconSet>(args.Detail, out var iconSet))
        {
            return;
        }

        this.CurrentIconSet = iconSet;
        await ApplyIconSetAsync(this.iconRegistry, iconSet);
    }

    // Material Symbols の SVG を独自コレクションとして登録する（グリッドの表示はまだ変わらない）
    private static Task RegisterMaterialSymbolsAsync(IgbIcon icon) =>
        Task.WhenAll(MaterialSymbolsSvgs.All.Select(svg =>
            icon.RegisterIconFromTextAsync(svg.Key, svg.Value, MaterialSymbolsSvgs.Collection)));

    // グリッド内部のアイコンエイリアスの参照先を、選択されたアイコンセットに切り替える
    private static Task ApplyIconSetAsync(IgbIcon icon, IconSet iconSet) =>
        Task.WhenAll(GridIconAliases.All.Select(alias =>
            icon.SetIconRefAsync(alias.Alias, "default", iconSet switch
            {
                IconSet.MaterialSymbols => CreateIconMeta(alias.SymbolName, MaterialSymbolsSvgs.Collection),
                _ => CreateIconMeta(alias.DefaultName, alias.DefaultCollection),
            })));

    // IgbIconMeta はコンポーネントとして実装されているが、SetIconRef の引数としてコードから生成するのが公式の使い方
#pragma warning disable BL0005
    private static IgbIconMeta CreateIconMeta(string name, string collection) =>
        new() { Name = name, Collection = collection };
#pragma warning restore BL0005
}
