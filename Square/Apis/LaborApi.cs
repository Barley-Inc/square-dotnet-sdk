namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Request.Configuration;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// LaborApi.
    /// </summary>
    internal class LaborApi : BaseApi, ILaborApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaborApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal LaborApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter the returned `BreakType` results to only those that are associated with the specified location..</param>
        /// <param name="limit">Optional parameter: The maximum number of `BreakType` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `BreakType` results to fetch..</param>
        /// <returns>Returns the Models.ListBreakTypesResponse response from the API call.</returns>
        public Models.ListBreakTypesResponse ListBreakTypes(
                string locationId = null,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListBreakTypesResponse> t = this.ListBreakTypesAsync(locationId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `BreakType` instances for a business.
        /// </summary>
        /// <param name="locationId">Optional parameter: Filter the returned `BreakType` results to only those that are associated with the specified location..</param>
        /// <param name="limit">Optional parameter: The maximum number of `BreakType` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `BreakType` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBreakTypesResponse response from the API call.</returns>
        public async Task<Models.ListBreakTypesResponse> ListBreakTypesAsync(
                string locationId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/break-types");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "location_id", locationId },
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListBreakTypesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `break_name`.
        /// - `expected_duration`.
        /// - `is_paid`.
        /// You can only have three `BreakType` instances per location. If you attempt to add a fourth.
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location.".
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBreakTypeResponse response from the API call.</returns>
        public Models.CreateBreakTypeResponse CreateBreakType(
                Models.CreateBreakTypeRequest body)
        {
            Task<Models.CreateBreakTypeResponse> t = this.CreateBreakTypeAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new `BreakType`.
        /// A `BreakType` is a template for creating `Break` objects.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `break_name`.
        /// - `expected_duration`.
        /// - `is_paid`.
        /// You can only have three `BreakType` instances per location. If you attempt to add a fourth.
        /// `BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location.".
        /// is returned.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBreakTypeResponse response from the API call.</returns>
        public async Task<Models.CreateBreakTypeResponse> CreateBreakTypeAsync(
                Models.CreateBreakTypeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/break-types");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateBreakTypeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being deleted..</param>
        /// <returns>Returns the Models.DeleteBreakTypeResponse response from the API call.</returns>
        public Models.DeleteBreakTypeResponse DeleteBreakType(
                string id)
        {
            Task<Models.DeleteBreakTypeResponse> t = this.DeleteBreakTypeAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes an existing `BreakType`.
        /// A `BreakType` can be deleted even if it is referenced from a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteBreakTypeResponse response from the API call.</returns>
        public async Task<Models.DeleteBreakTypeResponse> DeleteBreakTypeAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/break-types/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteBreakTypeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a single `BreakType` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being retrieved..</param>
        /// <returns>Returns the Models.GetBreakTypeResponse response from the API call.</returns>
        public Models.GetBreakTypeResponse GetBreakType(
                string id)
        {
            Task<Models.GetBreakTypeResponse> t = this.GetBreakTypeAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `BreakType` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBreakTypeResponse response from the API call.</returns>
        public async Task<Models.GetBreakTypeResponse> GetBreakTypeAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/break-types/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.GetBreakTypeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBreakTypeResponse response from the API call.</returns>
        public Models.UpdateBreakTypeResponse UpdateBreakType(
                string id,
                Models.UpdateBreakTypeRequest body)
        {
            Task<Models.UpdateBreakTypeResponse> t = this.UpdateBreakTypeAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an existing `BreakType`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `BreakType` being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBreakTypeResponse response from the API call.</returns>
        public async Task<Models.UpdateBreakTypeResponse> UpdateBreakTypeAsync(
                string id,
                Models.UpdateBreakTypeRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/break-types/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateBreakTypeResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter the returned wages to only those that are associated with the specified employee..</param>
        /// <param name="limit">Optional parameter: The maximum number of `EmployeeWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <returns>Returns the Models.ListEmployeeWagesResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListEmployeeWagesResponse ListEmployeeWages(
                string employeeId = null,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListEmployeeWagesResponse> t = this.ListEmployeeWagesAsync(employeeId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `EmployeeWage` instances for a business.
        /// </summary>
        /// <param name="employeeId">Optional parameter: Filter the returned wages to only those that are associated with the specified employee..</param>
        /// <param name="limit">Optional parameter: The maximum number of `EmployeeWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEmployeeWagesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListEmployeeWagesResponse> ListEmployeeWagesAsync(
                string employeeId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/employee-wages");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "employee_id", employeeId },
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListEmployeeWagesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a single `EmployeeWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `EmployeeWage` being retrieved..</param>
        /// <returns>Returns the Models.GetEmployeeWageResponse response from the API call.</returns>
        [Obsolete]
        public Models.GetEmployeeWageResponse GetEmployeeWage(
                string id)
        {
            Task<Models.GetEmployeeWageResponse> t = this.GetEmployeeWageAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `EmployeeWage` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `EmployeeWage` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetEmployeeWageResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.GetEmployeeWageResponse> GetEmployeeWageAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/employee-wages/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.GetEmployeeWageResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete workday for a single employee.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `employee_id`.
        /// - `start_at`.
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:.
        /// - The `status` of the new `Shift` is `OPEN` and the employee has another.
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future.
        /// - The `start_at` or `end_at` date overlaps another shift for the same employee.
        /// - The `Break` instances are set in the request and a break `start_at`.
        /// is before the `Shift.start_at`, a break `end_at` is after.
        /// the `Shift.end_at`, or both.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateShiftResponse response from the API call.</returns>
        public Models.CreateShiftResponse CreateShift(
                Models.CreateShiftRequest body)
        {
            Task<Models.CreateShiftResponse> t = this.CreateShiftAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new `Shift`.
        /// A `Shift` represents a complete workday for a single employee.
        /// You must provide the following values in your request to this.
        /// endpoint:.
        /// - `location_id`.
        /// - `employee_id`.
        /// - `start_at`.
        /// An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:.
        /// - The `status` of the new `Shift` is `OPEN` and the employee has another.
        /// shift with an `OPEN` status.
        /// - The `start_at` date is in the future.
        /// - The `start_at` or `end_at` date overlaps another shift for the same employee.
        /// - The `Break` instances are set in the request and a break `start_at`.
        /// is before the `Shift.start_at`, a break `end_at` is after.
        /// the `Shift.end_at`, or both.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateShiftResponse response from the API call.</returns>
        public async Task<Models.CreateShiftResponse> CreateShiftAsync(
                Models.CreateShiftRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/shifts");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateShiftResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:.
        /// - Location IDs.
        /// - Employee IDs.
        /// - Shift status (`OPEN` and `CLOSED`).
        /// - Shift start.
        /// - Shift end.
        /// - Workday details.
        /// The list can be sorted by:.
        /// - `start_at`.
        /// - `end_at`.
        /// - `created_at`.
        /// - `updated_at`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchShiftsResponse response from the API call.</returns>
        public Models.SearchShiftsResponse SearchShifts(
                Models.SearchShiftsRequest body)
        {
            Task<Models.SearchShiftsResponse> t = this.SearchShiftsAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `Shift` records for a business.
        /// The list to be returned can be filtered by:.
        /// - Location IDs.
        /// - Employee IDs.
        /// - Shift status (`OPEN` and `CLOSED`).
        /// - Shift start.
        /// - Shift end.
        /// - Workday details.
        /// The list can be sorted by:.
        /// - `start_at`.
        /// - `end_at`.
        /// - `created_at`.
        /// - `updated_at`.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchShiftsResponse response from the API call.</returns>
        public async Task<Models.SearchShiftsResponse> SearchShiftsAsync(
                Models.SearchShiftsRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/shifts/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchShiftsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being deleted..</param>
        /// <returns>Returns the Models.DeleteShiftResponse response from the API call.</returns>
        public Models.DeleteShiftResponse DeleteShift(
                string id)
        {
            Task<Models.DeleteShiftResponse> t = this.DeleteShiftAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Deletes a `Shift`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being deleted..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteShiftResponse response from the API call.</returns>
        public async Task<Models.DeleteShiftResponse> DeleteShiftAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/shifts/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.DeleteShiftResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a single `Shift` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being retrieved..</param>
        /// <returns>Returns the Models.GetShiftResponse response from the API call.</returns>
        public Models.GetShiftResponse GetShift(
                string id)
        {
            Task<Models.GetShiftResponse> t = this.GetShiftAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `Shift` specified by `id`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `Shift` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetShiftResponse response from the API call.</returns>
        public async Task<Models.GetShiftResponse> GetShiftAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/shifts/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.GetShiftResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have.
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`.
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateShiftResponse response from the API call.</returns>
        public Models.UpdateShiftResponse UpdateShift(
                string id,
                Models.UpdateShiftRequest body)
        {
            Task<Models.UpdateShiftResponse> t = this.UpdateShiftAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates an existing `Shift`.
        /// When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have.
        /// the `end_at` property set to a valid RFC-3339 datetime string.
        /// When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`.
        /// set on each `Break`.
        /// </summary>
        /// <param name="id">Required parameter: The ID of the object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateShiftResponse response from the API call.</returns>
        public async Task<Models.UpdateShiftResponse> UpdateShiftAsync(
                string id,
                Models.UpdateShiftRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/shifts/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateShiftResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter the returned wages to only those that are associated with the specified team member..</param>
        /// <param name="limit">Optional parameter: The maximum number of `TeamMemberWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <returns>Returns the Models.ListTeamMemberWagesResponse response from the API call.</returns>
        public Models.ListTeamMemberWagesResponse ListTeamMemberWages(
                string teamMemberId = null,
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListTeamMemberWagesResponse> t = this.ListTeamMemberWagesAsync(teamMemberId, limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a paginated list of `TeamMemberWage` instances for a business.
        /// </summary>
        /// <param name="teamMemberId">Optional parameter: Filter the returned wages to only those that are associated with the specified team member..</param>
        /// <param name="limit">Optional parameter: The maximum number of `TeamMemberWage` results to return per page. The number can range between 1 and 200. The default is 200..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `EmployeeWage` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberWagesResponse response from the API call.</returns>
        public async Task<Models.ListTeamMemberWagesResponse> ListTeamMemberWagesAsync(
                string teamMemberId = null,
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/team-member-wages");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListTeamMemberWagesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by `id `.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `TeamMemberWage` being retrieved..</param>
        /// <returns>Returns the Models.GetTeamMemberWageResponse response from the API call.</returns>
        public Models.GetTeamMemberWageResponse GetTeamMemberWage(
                string id)
        {
            Task<Models.GetTeamMemberWageResponse> t = this.GetTeamMemberWageAsync(id);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single `TeamMemberWage` specified by `id `.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `TeamMemberWage` being retrieved..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTeamMemberWageResponse response from the API call.</returns>
        public async Task<Models.GetTeamMemberWageResponse> GetTeamMemberWageAsync(
                string id,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/team-member-wages/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.GetTeamMemberWageResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of `WorkweekConfigs` results to return per page..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `WorkweekConfig` results to fetch..</param>
        /// <returns>Returns the Models.ListWorkweekConfigsResponse response from the API call.</returns>
        public Models.ListWorkweekConfigsResponse ListWorkweekConfigs(
                int? limit = null,
                string cursor = null)
        {
            Task<Models.ListWorkweekConfigsResponse> t = this.ListWorkweekConfigsAsync(limit, cursor);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of `WorkweekConfig` instances for a business.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of `WorkweekConfigs` results to return per page..</param>
        /// <param name="cursor">Optional parameter: A pointer to the next page of `WorkweekConfig` results to fetch..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListWorkweekConfigsResponse response from the API call.</returns>
        public async Task<Models.ListWorkweekConfigsResponse> ListWorkweekConfigsAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/workweek-configs");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "cursor", cursor },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListWorkweekConfigsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `WorkweekConfig` object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateWorkweekConfigResponse response from the API call.</returns>
        public Models.UpdateWorkweekConfigResponse UpdateWorkweekConfig(
                string id,
                Models.UpdateWorkweekConfigRequest body)
        {
            Task<Models.UpdateWorkweekConfigResponse> t = this.UpdateWorkweekConfigAsync(id, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a `WorkweekConfig`.
        /// </summary>
        /// <param name="id">Required parameter: The UUID for the `WorkweekConfig` object being updated..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateWorkweekConfigResponse response from the API call.</returns>
        public async Task<Models.UpdateWorkweekConfigResponse> UpdateWorkweekConfigAsync(
                string id,
                Models.UpdateWorkweekConfigRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/labor/workweek-configs/{id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "id", id },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateWorkweekConfigResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}