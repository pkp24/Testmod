\
using RimWorld;
using Verse;
using UnityEngine;

namespace MyMenuButtonMod
{
    /// <summary>
    /// Window that pops up when the toolbar button is clicked.
    /// </summary>
    public class MainTabWindow_MyMenu : MainTabWindow
    {
        public override Vector2 InitialSize => new Vector2(600f, 480f);
        public override MainTabWindowAnchor Anchor => MainTabWindowAnchor.Center;

        public MainTabWindow_MyMenu()
        {
            layer = WindowLayer.GameUI;
            forcePause = false;
            absorbInputAroundWindow = true;
            doCloseX = true;
            closeOnClickedOutside = true;
        }

        private Vector2 scrollPos = Vector2.zero;

        public override void DoWindowContents(Rect inRect)
        {
            Text.Font = GameFont.Medium;
            Widgets.Label(new Rect(inRect.x, inRect.y, inRect.width, 35f), "My Menu");

            Text.Font = GameFont.Small;
            const float topPadding = 40f;
            var viewRect = new Rect(0f, 0f, inRect.width - 20f, 800f);
            var outRect = new Rect(inRect.x, inRect.y + topPadding,
                                   inRect.width, inRect.height - topPadding);

            Widgets.BeginScrollView(outRect, ref scrollPos, viewRect);

            float curY = 0f;

            if (Widgets.ButtonText(new Rect(0f, curY, 140f, 30f), "Say hello"))
            {
                Messages.Message("Hello from MyMenuButtonMod!", MessageTypeDefOf.PositiveEvent);
            }
            curY += 40f;

            Widgets.Label(new Rect(0f, curY, viewRect.width, 24f),
                          "Add your own controls here …");

            Widgets.EndScrollView();
        }
    }
}
