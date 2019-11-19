using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using SharedCode;
using System.Threading.Tasks;
using Utility;

namespace OneTalent
{
    public class ApplyFragment : Fragment
    {
        Button applyButton;
        TextView staticMessage;
        RecyclerView recyclerView;
        CardAdapter cardAdapter;
        ImageView backImage;
        TextView dashBoardTextView;
        List<ResignationDetailModel> list;
        ResignationDetailModel resignationDetailModel;
        ResignationListViewModel resignationListViewModel;
       
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            var action = CallApi();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.ApplyFragment, container, false);
            UIReference(v);
            UIClick();
            backImage.Visibility = ViewStates.Gone;
            resignationDetailModel = new ResignationDetailModel();
            return v;
        }

        private void UIReference(View view)
        {
            applyButton = view.FindViewById<Button>(Resource.Id.applyButton);
            staticMessage = view.FindViewById<TextView>(Resource.Id.staticMessage);
            backImage = view.FindViewById<ImageView>(Resource.Id.backButton);
            dashBoardTextView = view.FindViewById<TextView>(Resource.Id.textViewResignationStatus);
            dashBoardTextView.Text = Message.ResignationApply;
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
        }

        private void UIClick()
        {
            applyButton.Click += ApplyButton_Click;
        }

        private void CardAdapter_itemClick(object sender, ViewHolderAdapterClickEventArgs e)
        {
            int id = list[e.Position].employeeResignationId;
            Bundle bundle = new Bundle();
            bundle.PutInt("resignationId", id);
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            ResignationStatusFragment resignationStatusFragment = new ResignationStatusFragment();
            resignationStatusFragment.Arguments = bundle;
            transaction.Replace(Resource.Id.frameLayout, resignationStatusFragment);
            transaction.Commit();
        }

        public async Task CallApi()
        {
            resignationListViewModel = new ResignationListViewModel();
            list = new List<ResignationDetailModel>();
            ProgressIndicator.Show(Context);
            list = await resignationListViewModel.GetDetailsList();
            var revokeStatus = list.Select(x => x.status == Convert.ToByte(StatusEnum.statusEnum.Revoked)).LastOrDefault();
            var rejectedByRM = list.Select(x => x.status == Convert.ToByte(StatusEnum.statusEnum.RejectedByRM)).LastOrDefault();
            var rejectedByHR = list.Select(x => x.status == Convert.ToByte(StatusEnum.statusEnum.RejectedByHR)).LastOrDefault();
            if (revokeStatus || rejectedByRM || rejectedByHR)
            {
                applyButton.Enabled = true;
            }
            else
            {
                applyButton.Visibility = ViewStates.Gone;
            }
            if (list != null && list.Count > 0 )
            {
                staticMessage.Visibility = ViewStates.Invisible;
                recyclerView.Visibility = ViewStates.Visible;
                recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
                cardAdapter = new CardAdapter(list);
                recyclerView.SetAdapter(cardAdapter);
                cardAdapter.NotifyDataSetChanged();
                cardAdapter.itemClick += CardAdapter_itemClick;
            }
            else
            {
                applyButton.Visibility = ViewStates.Visible;
                staticMessage.Text = Message.NotApplyed;
                recyclerView.Visibility = ViewStates.Invisible;
            }
            ProgressIndicator.Hide();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            LoadFragment(new ApplyResignationFragment());
        }

        public void LoadFragment(Fragment fragment)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frameLayout, fragment);
            transaction.AddToBackStack(null);
            transaction.Commit();
        }
    }
}