using Biblioteek.Types;
using System;

namespace Biblioteek.Katalogus
{
    public class SignalEditBoek
    {
        public event EventHandler<BoekNommer> Edit;

        public event EventHandler<BoekNommer> Finished;

        public void EditThisBoekNow(BoekNommer boekNommer)
        {
            this.Edit?.Invoke(this, boekNommer);
        }

        public void FinishedEditing(BoekNommer boekNommer)
        {
            this.Finished?.Invoke(this, boekNommer);
        }
    }
}