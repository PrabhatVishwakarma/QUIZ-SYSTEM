    using Microsoft.AspNetCore.Components;
    using Tool.Shared;

    namespace Tool.Client.Components
    {
        public class QuestionBase : ComponentBase
        {
            [Parameter]
            public QuestionViewModel? Question { get; set; }

            [Parameter]
            public int serialNo { get; set; }

        }
    }
