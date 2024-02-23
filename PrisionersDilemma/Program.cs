using System.Numerics;
using PrisionersDilemma.Core;
using Raylib_cs;
using static Raylib_cs.Raylib;

Runner runner = new("PrisionersDilemma.Core.Strategies");

//Dictionary<string, double> contestResults = runner.RunMeanContest(
//    contests: 200,
//    rounds: 200,
//    noise: 0.1
//);

//contestResults
//    .ToList()
//    .OrderByDescending(x => x.Value)
//    .ToList()
//    .ForEach(x => Console.WriteLine($"{x.Key}: {(int)x.Value} points"));

MatchResults matchResult = runner.RunMatch("AllD", "Pavlov", rounds: 15, noise: 0.0);
Console.WriteLine(matchResult);

SetConfigFlags(ConfigFlags.Msaa4xHint | ConfigFlags.ResizableWindow);
SetTargetFPS(60);
InitWindow(1000, 300, "Prisioners Dilemma");

//SetTextureFilter(GetTextureDefault(), TextureFilter.Trilinear);
while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.White);
    DrawMatchResults(matchResult, new Vector2(20, 20));
    EndDrawing();
}

CloseWindow();

void DrawRectangleTickLine(int x, int y, int w, int h, int tickness, Color color)
{
    var halfTickness = tickness / 2;
    DrawRectangle(x - halfTickness, y - halfTickness, w + tickness, h + tickness, color);
    DrawRectangle(x + halfTickness, y + halfTickness, w - tickness, h - tickness, Color.White);
}
void DrawCircleTickLine(int x, int y, float radius, int tickness, Color tickcClor, Color fillColor)
{
    DrawCircle(x, y, radius + tickness / 2, tickcClor);

    DrawCircle(x, y, radius - tickness / 2, fillColor);
}

void DrawBoundedGraphic(
    int x,
    int y,
    int w,
    int h,
    int tickness,
    Color color,
    int padding,
    Action<int, int> action
)
{
    DrawRectangleTickLine(x, y, w, h, tickness, color);
    action.Invoke(x + padding, y + padding);
}

void DrawBoundedText(
    int x,
    int y,
    int w,
    int h,
    int tickness,
    Color color,
    string text,
    int textSize,
    int padding
)
{
    DrawBoundedGraphic(
        x,
        y,
        w,
        h,
        tickness,
        color,
        padding,
        (textX, textY) => DrawText(text, x + padding, y + padding, textSize, color)
    );
}

void DrawMatchResults(MatchResults matchResults, Vector2 position)
{
    const int actionSide = 40;
    const int circleRadius = (actionSide - 8) / 2;
    const int padding = 10;
    const int textWidth = 250;
    const int scoreWidth = 100;
    int startActionsX = (int)position.X + textWidth + scoreWidth;
    const int boxLineWidth = 2;
    const int textSize = 20;

    ////// Names
    DrawBoundedText(
        (int)position.X,
        (int)position.Y,
        textWidth,
        actionSide,
        boxLineWidth * 2,
        Color.DarkGray,
        matchResults.Content1Results.StrategyName,
        textSize,
        padding
    );
    DrawBoundedText(
        (int)position.X,
        (int)position.Y + actionSide,
        textWidth,
        actionSide,
        boxLineWidth * 2,
        Color.DarkGray,
        matchResults.Content2Results.StrategyName,
        textSize,
        padding
    );
    // Scores
    DrawBoundedText(
        (int)position.X + textWidth,
        (int)position.Y,
        scoreWidth,
        actionSide,
        boxLineWidth * 2,
        Color.DarkGray,
        matchResults.Content1Results.Points.ToString(),
        textSize,
        padding
    );
    DrawBoundedText(
        (int)position.X + textWidth,
        (int)position.Y + actionSide,
        scoreWidth,
        actionSide,
        boxLineWidth * 2,
        Color.DarkGray,
        matchResults.Content2Results.Points.ToString(),
        textSize,
        padding
    );

    // Drawing actions
    var totalActions = matchResults.Content1Results.Actions.Count();
    for (int i = 0; i < totalActions; i++)
    {
        var action1 = matchResults.Content1Results.Actions[i];
        var action2 = matchResults.Content2Results.Actions[i];
        //Draw action 1
        DrawBoundedGraphic(
            startActionsX + actionSide * i,
            (int)position.Y,
            actionSide,
            actionSide,
            boxLineWidth * 2,
            Color.DarkGray,
            0,
            (cX, cY) =>
                DrawCircleTickLine(
                    cX + actionSide / 2,
                    cY + actionSide / 2,
                    circleRadius,
                    0,
                    Color.DarkGray,
                    action1 ? Color.Green : Color.Red
                )
        );

        DrawBoundedGraphic(
            startActionsX + actionSide * i,
            (int)position.Y + actionSide,
            actionSide,
            actionSide,
            boxLineWidth * 2,
            Color.DarkGray,
            0,
            (cX, cY) =>
                DrawCircleTickLine(
                    cX + actionSide / 2,
                    cY + actionSide / 2,
                    circleRadius,
                    0,
                    Color.DarkGray,
                    action1 ? Color.Green : Color.Red
                )
        );
    }
}

// https://www.jasss.org/20/4/12.html#axelrod2006
// https://github.com/Mark-MDO47/PrisonDilemmaTourney?tab=readme-ov-file
// [c, c] -> R + R,[d, d] -> P + P,[d, c] -> T + S
