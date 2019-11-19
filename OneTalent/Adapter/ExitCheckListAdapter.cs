using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SharedCode;
using Utility;

namespace OneTalent
{
    public class ExitCheckListAdapter : RecyclerView.Adapter
    {
        List<ExitCheckListDetailModel> exitCheckListDetails;

        public ExitCheckListAdapter(List<ExitCheckListDetailModel> exitCheckListDetails)
        {
            this.exitCheckListDetails = exitCheckListDetails;
        }

        public event EventHandler<ExitCheckListAdapterClick> ItemClick;
        public override int ItemCount => exitCheckListDetails.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vholder = holder as ExitCheckListViewHolder;
            
            if (exitCheckListDetails[position].status == Convert.ToInt32(StatusEnum.statusEnum.NotStarted))
            {
                vholder.textViewActivityName.Text = exitCheckListDetails[position].activityName;
                vholder.textViewDomain.Text = exitCheckListDetails[position].domainName;
                vholder.textViewNotStarted.Text = exitCheckListDetails[position].status.ToString();
            }
            if (exitCheckListDetails[position].status == Convert.ToInt32(StatusEnum.statusEnum.InProgress))
            {
                vholder.textViewActivityName.Text = exitCheckListDetails[position].activityName;
                vholder.textViewDomain.Text = exitCheckListDetails[position].domainName;
                vholder.textViewInProgress.Text = exitCheckListDetails[position].status.ToString();
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ExitCheckListCard_Item, parent, false);
            return new ExitCheckListViewHolder(view,OnClick);
        }

        void OnClick(ExitCheckListAdapterClick adapterClick) => ItemClick?.Invoke(this, adapterClick);
    }

    public class ExitCheckListViewHolder : RecyclerView.ViewHolder
    {
        public TextView textViewNotStarted { get; set; }
        public TextView textViewInProgress { get; set; }
        public TextView textViewActivityName { get; set; }
        public TextView textViewDomain { get; set; }
        public ExitCheckListViewHolder(View itemView, Action<ExitCheckListAdapterClick > action) : base(itemView)
        {
            textViewNotStarted = itemView.FindViewById<TextView>(Resource.Id.notStaredTextView);
            textViewInProgress = itemView.FindViewById<TextView>(Resource.Id.inProgressTextView);
            textViewActivityName = itemView.FindViewById<TextView>(Resource.Id.textViewActivityName);
            textViewDomain = itemView.FindViewById<TextView>(Resource.Id.textViewDomain);

            itemView.Click += (s, e) => action(new ExitCheckListAdapterClick
            {
                view = itemView,
                Position = AdapterPosition
            });
        }
    }

    public class ExitCheckListAdapterClick : EventArgs
    {
        public View view { get; set; }
        public int Position { get; set; }
    }
}