using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Vendors;
using Reggora.Api.Util;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class VendorStorage : Storage<Vendr, Api.Lender>
    {
        public VendorStorage(Api.Lender api) : base(api)
        {
        }
        public List<Vendr> All()
        {
            var result = new GetVendorsRequest().Execute(Api.Client);
            var fetchedVendors = result.Data.Vendors;
            List<Vendr> vendors = new List<Vendr>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedVendors.Count; i++)
                {
                    Vendr tempVendor = new Vendr();
                    tempVendor.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedVendors[i]));
                    vendors.Add(tempVendor);
                }
            }
            return vendors;
        }

        public override Vendr Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetVendorRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new Vendr();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data.Vendor));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public List<Vendr> GetByZone(List<string> zones)
        {
            var result = new GetVendorsByZoneRequest(zones).Execute(Api.Client);
            var fetchedVendors = result.Data.Vendors;
            List<Vendr> vendors = new List<Vendr>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedVendors.Count; i++)
                {
                    Vendr tempVendor = new Vendr();
                    tempVendor.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedVendors[i]));
                    vendors.Add(tempVendor);
                }
            }
            return vendors;
        }

        public List<Vendr> GetByBranch(string branchId)
        {
            var result = new GetVendorsByBranchRequest(branchId).Execute(Api.Client);
            var fetchedVendors = result.Data.Vendors;
            List<Vendr> vendors = new List<Vendr>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedVendors.Count; i++)
                {
                    Vendr tempVendor = new Vendr();
                    tempVendor.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedVendors[i]));
                    vendors.Add(tempVendor);
                }
            }
            return vendors;
        }

        public override void Save(Vendr vendor)
        {

        }

        public string Create(Vendr vendor)
        {
            string response = null;
            var result = new InviteVendorRequest(vendor).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                vendor.Clean();

            }

            return response;
        }

        public string Edit(Vendr vendor)
        {
            string response = "";
            var result = new EditVendorRequest(vendor).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                vendor.Clean();
            }
            return response;
        }

        public string Delete(string id)
        {
            string response = null;
            var result = new DeleteVendorRequest(id).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }
    }
}
