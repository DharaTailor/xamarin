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
  public  class CardAdapter : RecyclerView.Adapter
    {
        List<ResignationDetailModel> list;

        public CardAdapter(List<ResignationDetailModel> list)
        {
            this.list = list;
        }

        public event EventHandler<ViewHolderAdapterClickEventArgs> itemClick;

        public override int ItemCount => list.Count;

        void OnClick(ViewHolderAdapterClickEventArgs args) => itemClick?.Invoke(this, args);

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vholder = holder as ViewHolderAdapter;
            vholder.txtRequestDate.Text = "Requested Date : " + list[position].requestDate.ToString("dd/MM/yyyy");

            if(list[position].status == Convert.ToByte(StatusEnum.statusEnum.Initiated))
            {
                vholder.linearReasonRelive.Visibility = ViewStates.Visible;
                vholder.editTextReasonRelive.Text = list[position].resignationReason;
                vholder.txtInitiat.Visibility = ViewStates.Visible;
                vholder.txtInitiat.Text = StatusEnum.statusEnum.Initiated.ToString();
            }
            else if(list[position].status == Convert.ToByte(StatusEnum.statusEnum.Revoked))
            {
                vholder.linearRevoked.Visibility = ViewStates.Visible;
                vholder.editTextRevoke.Text = list[position].revokeReason.ToString();
                vholder.textViewRevoke.Visibility = ViewStates.Visible;
                vholder.textViewRevoke.Text = StatusEnum.statusEnum.Revoked.ToString();
                vholder.linearReasonRelive.Visibility = ViewStates.Gone;
                vholder.txtInitiat.Visibility = ViewStates.Gone;
            }
            else if(list[position].status == Convert.ToByte(StatusEnum.statusEnum.AcceptedByRM))
            {
                vholder.textViewAccepted.Visibility = ViewStates.Visible;
                vholder.textViewAccepted.Text = StatusEnum.statusEnum.AcceptedByRM.ToString();
                vholder.linearReasonRelive.Visibility = ViewStates.Visible;
                vholder.editTextReasonRelive.Text = list[position].resignationReason;
            }
            else if (list[position].status == Convert.ToByte(StatusEnum.statusEnum.RejectedByRM))
            {
                vholder.textviewReject.Visibility = ViewStates.Visible;
                vholder.textviewReject.Text = StatusEnum.statusEnum.RejectedByRM.ToString();
                vholder.linearReasonRelive.Visibility = ViewStates.Visible;
                vholder.editTextReasonRelive.Text = list[position].resignationReason;
            }

            else if (list[position].status==Convert.ToByte(StatusEnum.statusEnum.AcceptedByHR))
            {
                vholder.textViewAccepted.Visibility = ViewStates.Visible;
                vholder.textViewAccepted.Text = StatusEnum.statusEnum.AcceptedByHR.ToString();
                vholder.linearReasonRelive.Visibility = ViewStates.Visible;
                vholder.editTextReasonRelive.Text = list[position].resignationReason;
            }
            else if (list[position].status==Convert.ToByte(StatusEnum.statusEnum.RejectedByHR))
            {
                vholder.textviewReject.Visibility = ViewStates.Visible;
                vholder.textviewReject.Text = StatusEnum.statusEnum.RejectedByHR.ToString();
                vholder.linearReasonRelive.Visibility = ViewStates.Visible;
                vholder.editTextReasonRelive.Text = list[position].resignationReason;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Card_Item,parent,false);
            return new ViewHolderAdapter(itemView,OnClick);
        }
    }

    public class ViewHolderAdapter : RecyclerView.ViewHolder
    {
        public TextView txtRequestDate { get; set; }
        public LinearLayout linearReasonRelive { get; set; }
        public TextView editTextReasonRelive { get; set; }
        public TextView txtInitiat { get; set; }
        public TextView textViewAccepted { get; set; }
        public TextView textviewReject { get; set; }
        public TextView textViewRevoke { get; set; }
        public LinearLayout linearRevoked { get; set; }
        public TextView editTextRevoke { get; set; }

        public ViewHolderAdapter(View itemView, Action<ViewHolderAdapterClickEventArgs> clickListener) : base(itemView)
        {
            txtRequestDate = itemView.FindViewById<TextView>(Resource.Id.Date);
            linearReasonRelive = itemView.FindViewById<LinearLayout>(Resource.Id.linearReason);
            editTextReasonRelive = itemView.FindViewById<TextView>(Resource.Id.editReasonRelive);
            txtInitiat = itemView.FindViewById<TextView>(Resource.Id.textViewInitiat);
            textViewAccepted = itemView.FindViewById<TextView>(Resource.Id.textViewAcceptedStatus);
            textviewReject = itemView.FindViewById<TextView>(Resource.Id.textViewRejected);
            linearRevoked = itemView.FindViewById<LinearLayout>(Resource.Id.linearReasonRevoke);
            textViewRevoke = itemView.FindViewById<TextView>(Resource.Id.textViewRevoke);
            editTextRevoke = itemView.FindViewById<TextView>(Resource.Id.editReasonRevoked);

            itemView.Click += (sender, e) => clickListener(new ViewHolderAdapterClickEventArgs
            {
                View = itemView,
                Position = AdapterPosition
            });
        }
    }

    public class ViewHolderAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}